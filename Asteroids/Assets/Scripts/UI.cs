using System.Collections.Generic;
using UnityEngine;




public class UI : MonoBehaviour
{
    public GameObject startMenu = null;
    public GameObject livesCounter = null;
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



    public Game.State state
    {
        set
        {
            startMenu.SetActive(value == Game.State.BeforeGame);
            livesCounter.SetActive(value == Game.State.InGame || value == Game.State.RoundOver);
            roundOverMenu.SetActive(value == Game.State.RoundOver);
        }
    }
}
