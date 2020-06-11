using System.Linq;
using UnityEngine;



public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid = null;
    public float secondsBetweenSpawns = 4f;
    public float maxSpeed = 4f;



    private float nextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + secondsBetweenSpawns;
        }
    }



    public void Spawn()
    {
        var spawned = Instantiate(asteroid);
        var moving = spawned.GetComponent<Moving>();
        moving.velocity = Random.insideUnitCircle * maxSpeed;
        moving.position = Player.instance.position + (Vector2)Universe.instance.bounds.extents;
    }
}
