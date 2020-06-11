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



    private Player _player = null;
    public static Player player => instance._player;

    private AsteroidSpawner _asteroidSpawner = null;
    public static AsteroidSpawner asteroidSpawner => instance._asteroidSpawner;



    private void OnEnable()
    {
        instance = this;
    }



    public void StartGame()
    {
        everPlayed = true;
        previousRoundsTime = 0f;
        livesRemaining = 3;
        StartRound();
    }



    public void EndGame()
    {
        state = State.BeforeGame;
    }



    public void StartRound()
    {
        state = State.InGame;
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
            state = State.RoundOver;
        }
    }



    public void Quit()
    {
        Application.Quit();
    }



    private State _state = State.BeforeGame;

    public State state
    {
        get => _state;
        private set
        {
            if (state == value) return;
            if (state == State.InGame)
            {
                previousRoundsTime = totalTime;
            }
            if (value == State.InGame)
            {
                currentRoundStart = Time.time;
            }
            _state = value;
            ui.state = value;
        }
    }



    public enum State
    {
        BeforeGame,
        InGame,
        RoundOver
    }



    private float previousRoundsTime = 0f;
    private float currentRoundStart = 0f;

    public float totalTime
    {
        get
        {
            if (state == State.InGame) return previousRoundsTime + Time.time - currentRoundStart;
            return previousRoundsTime;
        }
    }



    private bool _everPlayed = false;

    public bool everPlayed
    {
        get => _everPlayed;
        private set
        {
            _everPlayed = value;
        }
    }
}
