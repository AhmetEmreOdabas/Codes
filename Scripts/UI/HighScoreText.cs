using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreText : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;

    private void Start() 
    {
        highscoreText.text = "HighScore:" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update() 
    {
        if(PlayerStats.Score > PlayerPrefs.GetInt("HighScore", 0))
        {
             PlayerPrefs.SetInt("HighScore", PlayerStats.Score);
             highscoreText.text = "HighScore:" + PlayerStats.Score.ToString();
        }
    }
}
