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
        // destroy asteroids which may have been left over from the last round
        List<Asteroid> asteroidsToDestroy = new List<Asteroid>(Asteroid.enabledAsteroids);
        foreach (var asteroid in asteroidsToDestroy)
        {
            Destroy(asteroid.gameObject);
        }
        _asteroidSpawner = Instantiate(asteroidSpawnerPrefab).GetComponent<AsteroidSpawner>();
        _player = Instantiate(playerPrefab).GetComponent<Player>();
    }



    public void EndRound()
    {
        Destroy(player.gameObject);
        _player = null;
        Destroy(asteroidSpawner.gameObject);
        _asteroidSpawner = null;
    }



    private Player _player = null;
    public static Player player => instance._player;

    private AsteroidSpawner _asteroidSpawner = null;
    public static AsteroidSpawner asteroidSpawner => instance._asteroidSpawner;
}
