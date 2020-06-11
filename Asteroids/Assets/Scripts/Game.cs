using System.Collections.Generic;
using UnityEngine;



public class Game : MonoBehaviour
{
    public static Game instance = null;

    public GameObject playerPrefab = null;
    public GameObject asteroidSpawnerPrefab = null;

    public UI ui = null;

    [HideInInspector]
    public int livesRemaining = 3;



    private void OnEnable()
    {
        instance = this;
    }



    public void StartGame()
    {
        livesRemaining = 3;
        StartRound();
    }



    public void EndGame()
    {
        ui.state = UI.State.GameOver;
    }



    public void StartRound()
    {
        ui.state = UI.State.InGame;
        ui.numLives = livesRemaining;
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

        livesRemaining -= 1;
        ui.numLives = livesRemaining;
        if (livesRemaining == 0)
        {
            EndGame();
        }
        else
        {
            ui.ShowRoundOverMenu();
        }
    }



    public void Quit()
    {
        Application.Quit();
    }



    private Player _player = null;
    public static Player player => instance._player;

    private AsteroidSpawner _asteroidSpawner = null;
    public static AsteroidSpawner asteroidSpawner => instance._asteroidSpawner;
}
