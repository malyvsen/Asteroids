using System.Collections;
using System.Collections.Generic;
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
        if (collidesWith.Count > 0)
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
