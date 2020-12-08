using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject turret;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public GameObject upgradedPrefabTwo;
    public int upgradeCostTwo;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}