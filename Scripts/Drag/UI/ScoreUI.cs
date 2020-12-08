using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Update() 
    {
        scoreText.text = "Score:" + PlayerStats.Score;
    }
}
