using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class Asteroid : Moving
{
    public float spawnSpeed = 4f;
    public List<GameObject> spawnOnExplode = new List<GameObject>();



    private void Start()
    {
        velocity += Random.insideUnitCircle * spawnSpeed;
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
        foreach (var toSpawn in spawnOnExplode)
        {
            LocalSpawn(toSpawn);
        }
        Destroy(gameObject);
    }
}
