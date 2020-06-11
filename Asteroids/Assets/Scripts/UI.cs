using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class UI : MonoBehaviour
{
    public GameObject startMenu = null;
    public GameObject inGameUI = null;
    public GameObject gameOverMenu = null;



    public State state
    {
        get
        {
            if (startMenu.activeSelf) return State.BeforeGame;
            if (inGameUI.activeSelf) return State.InGame;
            if (gameOverMenu.activeSelf) return State.GameOver;
            throw new System.Exception("All UI disabled");
        }

        set
        {
            startMenu.SetActive(value == State.BeforeGame);
            inGameUI.SetActive(value == State.InGame);
            gameOverMenu.SetActive(value == State.GameOver);
        }
    }



    public enum State
    {
        BeforeGame,
        InGame,
        GameOver
    }
}
