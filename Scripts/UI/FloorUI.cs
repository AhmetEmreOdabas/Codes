using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorUI : MonoBehaviour
{
    public Text upgradeCost;
    public Text sellAmount;
    public Button upgradeButton;
    public GameObject ui;
    private Node target;

    public void SetTarget(Node _target)
    {
          target = _target;

          transform.position = target.GetBuildPosition();

           if (!target.isUpgraded)
           {
              upgradeCost.text = target._turretManager.upgradeCost + "G";
              upgradeButton.interactable = true;
           }
            else if(target.isUpgraded && !target.isUpgradedTwo)
           {
               upgradeCost.text = target._turretManager.upgradeCostTwo + "G";
               upgradeButton.interactable = true;
           }
           else
           {
              upgradeCost.text = "Max Level";
              upgradeButton.interactable = false;
           }

           sellAmount.text = target._turretManager.GetSellAmount() + "G";

          ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        if(!target.isUpgraded)
        {
            target.UpgradeTurret();
            BuildManager.instance.DeselectFloor();
            return;
        }
        if(target.isUpgraded && !target.isUpgradedTwo)
        {
            target.UpgradeTurretTwo();
        }
        BuildManager.instance.DeselectFloor();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectFloor();
    }
}
