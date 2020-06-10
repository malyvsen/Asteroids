using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Universe : MonoBehaviour
{
    public static Universe instance = null;

    public Camera boundingCamera = null;



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



    private void Awake()
    {
        instance = this;
    }
}
