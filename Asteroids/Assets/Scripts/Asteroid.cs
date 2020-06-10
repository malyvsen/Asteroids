using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Asteroid : AsteroidsObject
{
    public float spawnSpeed = 4f;
    public List<GameObject> spawnOnExplode = new List<GameObject>();



    private void OnEnable()
    {
        velocity += Random.insideUnitCircle * spawnSpeed;
    }



    private void Update()
    {
        ApplyPhysics();
    }



    private void Explode()
    {
        foreach (var toSpawn in spawnOnExplode)
        {
            var spawned = Instantiate(toSpawn);
            var asteroidsObject = spawned.GetComponent<AsteroidsObject>();
            asteroidsObject.position = position;
            asteroidsObject.velocity = velocity; // randomized later in spawned OnEnable()
        }
    }
}
