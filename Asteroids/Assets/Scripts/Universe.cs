using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Universe : MonoBehaviour
{
    public static Universe instance = null;

    public Camera boundingCamera = null;
    public Camera sideCameraPrefab = null;



    public Bounds bounds
    {
        get
        {
            var cameraHeight = boundingCamera.orthographicSize * 2;
            var aspectRatio = (float)Screen.width / (float)Screen.height;
            var cameraWidth = cameraHeight * aspectRatio;
            return new Bounds(
                center: boundingCamera.transform.position,
                size: new Vector3(cameraWidth, cameraHeight)
            );
        }
    }



    public Vector2 Wrap(Vector2 position)
    {
        var relativePosition = position - (Vector2)bounds.min;
        var relativeWrapped = new Vector2(
            Utils.Mod(relativePosition.x, bounds.size.x),
            Utils.Mod(relativePosition.y, bounds.size.y)
        );
        return relativeWrapped + (Vector2)bounds.min;
    }



    public float Distance(Vector2 a, Vector2 b)
    {
        var aWrapped = Wrap(a);
        var bWrapped = Wrap(b);
        var minDistance = float.PositiveInfinity;
        for (var x = -1; x <= 1; x++)
        {
            for (var y = -1; y <= 1; y++)
            {
                var bShifted = bWrapped + new Vector2(bounds.size.x * x, bounds.size.y * y);
                var currentDistance = Vector2.Distance(aWrapped, bShifted);
                if (currentDistance < minDistance) minDistance = currentDistance;
            }
        }
        return minDistance;
    }



    private void Awake()
    {
        instance = this;
    }



    private void Start()
    {
        SpawnSideCameras();
    }



    private List<Camera> sideCameras = new List<Camera>();

    private void SpawnSideCameras()
    {
        for (var x = -1; x <= 1; x++)
        {
            for (var y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue; // central camera
                var newCameraObject = Instantiate(sideCameraPrefab, parent: transform);
                var newCamera = newCameraObject.GetComponent<Camera>();
                newCamera.orthographicSize = boundingCamera.orthographicSize;
                var translation = new Vector3(bounds.size.x * x, bounds.size.y * y);
                newCamera.transform.position = bounds.center - translation;
                sideCameras.Add(newCamera);
            }
        }
    }
}
