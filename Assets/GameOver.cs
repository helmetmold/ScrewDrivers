using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshPro Game_Over;
    public TextMeshPro YourScore;
    public TextMeshPro HighScore;

    public GameObject Lives_Manager;

    // Start is called before the first frame update
    void Start()
    {
        YourScore.text = Lives_Manager.GetComponent<LivesManager>().wave.ToString() + " Waves Destroyed";

        if (Lives_Manager.GetComponent<LivesManager>().wave > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Lives_Manager.GetComponent<LivesManager>().wave);
            Game_Over.GetComponent<TextMeshPro>().text = "New High Score!";
        }
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString() + " Waves Destroyed";

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
