using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class Asteroid : Moving
{
    public List<GameObject> spawnOnExplode = new List<GameObject>();
    public float explodeRadius = 2f;
    public float explodeSpeed = 4f;



    private void OnEnable()
    {
        enabledAsteroids.Add(this);
    }



    private void OnDisable()
    {
        enabledAsteroids.Remove(this);
    }



    private void Update()
    {
        ApplyPhysics();
        if (collisions.Any())
        {
            Explode();
        }
    }



    private void Explode()
    {
        var initialAngle = Random.Range(0f, 360f);
        for (var spawnIndex = 0; spawnIndex < spawnOnExplode.Count; spawnIndex++)
        {
            var toSpawn = spawnOnExplode[spawnIndex];
            var spawned = LocalSpawn(toSpawn);
            var angle = initialAngle + 360f * spawnIndex / spawnOnExplode.Count;
            var rotation = Quaternion.Euler(0f, 0f, angle);
            Vector2 headingVector = rotation * Vector3.up;
            spawned.position += headingVector * explodeRadius;
            spawned.velocity += headingVector * explodeSpeed;
        }
        Destroy(gameObject);
    }



    public static List<Asteroid> enabledAsteroids = new List<Asteroid>();
}
