using System.Linq;
using System.Collections.Generic;
using UnityEngine;




public class UI : MonoBehaviour
{
    public GameObject startMenu = null;
    public GameObject inGameUI = null;
    public GameObject roundOverMenu = null;

    public List<GameObject> lifeIcons = new List<GameObject>();



    public int numLives
    {
        set
        {
            for (var idx = 0; idx < lifeIcons.Count; idx++)
            {
                lifeIcons[idx].SetActive(idx < value);
            }
        }
    }



    public State state
    {
        set
        {
            startMenu.SetActive(value == State.BeforeGame);
            inGameUI.SetActive(value == State.InGame || value == State.RoundOver);
            roundOverMenu.SetActive(value == State.RoundOver);
        }
    }



    public enum State
    {
        BeforeGame,
        InGame,
        RoundOver
    }
}
