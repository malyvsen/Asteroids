using System.Collections.Generic;
using UnityEngine;



public class Game : MonoBehaviour
{
    public static Game instance = null;

    public GameObject playerPrefab = null;
    public GameObject asteroidSpawnerPrefab = null;



    private void OnEnable()
    {
        instance = this;
        StartRound();
    }



    public void StartRound()
    {
        asteroidSpawner = Instantiate(asteroidSpawnerPrefab).GetComponent<AsteroidSpawner>();
        List<Asteroid> asteroidsToDestroy = new List<Asteroid>(Asteroid.enabledAsteroids);
        foreach (var asteroid in asteroidsToDestroy)
        {
            Destroy(asteroid.gameObject);
        }
    }



    public void EndRound()
    {
        Destroy(asteroidSpawner.gameObject);
    }



    private AsteroidSpawner asteroidSpawner = null;
}
