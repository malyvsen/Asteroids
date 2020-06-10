using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AsteroidSpawner : MonoBehaviour
{
    public float secondsBetweenSpawns = 1f;
    public GameObject asteroid = null;



    private float nextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + secondsBetweenSpawns;
        }
    }



    private void Spawn()
    {
        var spawned = Instantiate(asteroid);
        var asteroidsObject = spawned.GetComponent<AsteroidsObject>();
        asteroidsObject.position = Player.instance.position + new Vector2(1f, 1f); // TODO: should spawn on opposite side of world
    }
}
