using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public GameObject turret;
    public TowerBlueprint _turretManager;
    public bool isUpgraded = false;
    public bool isUpgradedTwo = false;
    public Vector3 buildPosOffset;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (turret != null)
        {
            buildManager.SelectFloor(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + buildPosOffset;
    }

    void BuildTurret(TowerBlueprint turretManager)
    {
        if (PlayerStats.Money < turretManager.cost)
        {
            return;
        }

        PlayerStats.Money -= turretManager.cost;

        GameObject _turret = (GameObject)Instantiate(turretManager.turret, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        _turretManager = turretManager;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < _turretManager.upgradeCost)
        {
            return;
        }

        PlayerStats.Money -= _turretManager.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(_turretManager.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;
    }
    public void UpgradeTurretTwo()
    {
        if(isUpgraded == true)
        {
            if (PlayerStats.Money < _turretManager.upgradeCostTwo)
            {
                return;
            }

            PlayerStats.Money -= _turretManager.upgradeCostTwo;

            Destroy(turret);

            GameObject _turret = (GameObject)Instantiate(_turretManager.upgradedPrefabTwo, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            isUpgradedTwo = true;
        }
        
    }

    public void SellTurret()
    {
        PlayerStats.Money += _turretManager.GetSellAmount();

        isUpgraded = false;
        isUpgradedTwo = false;

        Destroy(turret);

        _turretManager = null;
    }
}
