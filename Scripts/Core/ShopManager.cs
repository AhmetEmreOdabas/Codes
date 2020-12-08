using UnityEngine;


public class ShopManager : MonoBehaviour
{
    public TowerBlueprint towerOne;
    public TowerBlueprint towerTwo;
    public TowerBlueprint towerThree;
    public TowerBlueprint towerFour;
    public TowerBlueprint towerFive;

    BuildManager buildManager;

    private void Start() 
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTowerOne()
    {
        buildManager.SelectTurretToBuild(towerOne);
    }
    public void SelectTowerTwo()
    {
        buildManager.SelectTurretToBuild(towerTwo);
    }
    public void SelectTowerThree()
    {
        buildManager.SelectTurretToBuild(towerThree);
    }
    public void SelectTowerFour()
    {
        buildManager.SelectTurretToBuild(towerFour);
    }
    public void SelectTowerFive()
    {
        buildManager.SelectTurretToBuild(towerFive);
    }
}
