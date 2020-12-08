using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private int rounds = 0;

    private void Start() 
    {
        rounds = PlayerStats.Rounds;
    }

    private void FixedUpdate() 
    {
        if(rounds < PlayerStats.Rounds)
        {
            rounds++;
            roundsText.text = "wave:" + rounds;
        }
    }
}
