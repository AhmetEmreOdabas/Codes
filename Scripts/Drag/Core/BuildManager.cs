using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Double instance issue");
            return;
        }
        instance = this;
    }
    public bool CanBuild { get { return turretToBuild != null; } }

    private TowerBlueprint turretToBuild;
    private Node selectedFloor;

    public FloorUI floorUI;

    public void SelectTurretToBuild(TowerBlueprint turret)
    {
        turretToBuild = turret;
        DeselectFloor();
    }

    public void SelectFloor(Node floor)
    {
        if (selectedFloor == floor)
        {
            DeselectFloor();
            return;
        }

        selectedFloor = floor;
        turretToBuild = null;

        floorUI.SetTarget(floor);
    }

    public void DeselectFloor()
    {
        selectedFloor = null;
        floorUI.Hide();
    }

    public TowerBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
