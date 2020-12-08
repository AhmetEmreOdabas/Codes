using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startingMoney = 50;

    public static int Lives;
    public int startingLives;

    public static int Rounds;

    public static int Score;


    private void Start()
    {
        Money = startingMoney;
        Lives = startingLives;
        Score = 0;
        Rounds = 0;
    }

    public void AddLives()
    {
        Lives += 10;
    }
}
