using System.Linq;
using UnityEngine;



public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid = null;
    public float secondsBetweenSpawns = 4f;
    public float baseSpeed = 4f;
    [Tooltip("Each next asteroid is this much faster")]
    public float speedup = 1f;



    private float nextSpawnTime = 0f;
    private int numSpawned = 0;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            numSpawned++;
        }
    }



    public void Spawn()
    {
        var spawned = Instantiate(asteroid);
        var moving = spawned.GetComponent<Moving>();
        var speed = baseSpeed + numSpawned * speedup;
        moving.velocity = Random.insideUnitCircle.normalized * speed;
        moving.position = Game.player.position + (Vector2)Universe.instance.bounds.extents;
    }
}
