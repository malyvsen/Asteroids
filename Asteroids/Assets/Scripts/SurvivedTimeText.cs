using UnityEngine;
using UnityEngine.UI;



public class SurvivedTimeText : MonoBehaviour
{
    public GameObject banner = null;
    public Text text = null;
    public string textTemplate = "You survived {} seconds";



    private void OnEnable()
    {
        banner.SetActive(Game.instance != null && Game.instance.everPlayed);
    }



    private void Update()
    {
        text.text = textTemplate.Replace("{}", Game.instance.totalTime.ToString("N0"));
    }
}
