using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private void FixedUpdate() 
    {
       moneyText.text = PlayerStats.Money.ToString() + "G";   
    }
}
