using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace CubeCastle.Managers
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] GameObject house, mill, mine, wall;
        private void Awake()
        {
            SaveSystem.GameData data = SaveSystem.Saving.LoadData();
            if (data != null){
                // Setting Resources on Start up from save
                ResourceManager.Instance.SetGold(data.gold);
                ResourceManager.Instance.SetWood(data.wood);
                ResourceManager.Instance.SetAvailPop(data.availPop);
                ResourceManager.Instance.SetTotalPop(data.totalPop);
                ResourceManager.Instance.SetMaxGold(data.maxGold);
                ResourceManager.Instance.SetMaxWood(data.maxWood);

                // Placing Buildings in correct positions on start up and setting variables in buildings
                foreach (SaveSystem.BuildingSaveData building in data.buildingSaveData)
                {
                    if (building.Equals(data.buildingSaveData[0])) { continue; }
                    Vector3 pos = new Vector3(building.position[0], building.position[1], building.position[2]);

                    GameObject newObject = null;
                    switch (building.buildingType)
                    {
                        case 0: //House
                            newObject = Instantiate(house);
                            newObject.transform.position = pos;
                            newObject.GetComponent<Buildings.BuildingData>().BuildingType = Buildings.BuildingData.BuildingStyle.House;
                            newObject.GetComponent<Buildings.BuildingData>().ResourceCurrent = building.resourceAmount;
                            newObject.GetComponent<Buildings.GridControl>().Building = false;
                            newObject.GetComponent<Buildings.BuildingControl>().Building = false;
                            Manager.Instance.AddtoHouses(newObject);

                            break;
                        case 1: //Mill
                            newObject = Instantiate(mill);
                            newObject.transform.position = pos;
                            newObject.GetComponent<Buildings.BuildingData>().BuildingType = Buildings.BuildingData.BuildingStyle.Mill;
                            newObject.GetComponent<Buildings.BuildingData>().ResourceCurrent = building.resourceAmount;
                            newObject.GetComponent<Buildings.GridControl>().Building = false;
                            newObject.GetComponent<Buildings.BuildingControl>().Building = false;
                            Manager.Instance.AddtoMills(newObject);
                            break;

                        case 2: //Mine
                            newObject = Instantiate(mine);
                            newObject.transform.position = pos;
                            newObject.GetComponent<Buildings.BuildingData>().BuildingType = Buildings.BuildingData.BuildingStyle.Mine;
                            newObject.GetComponent<Buildings.BuildingData>().ResourceCurrent = building.resourceAmount;
                            newObject.GetComponent<Buildings.GridControl>().Building = false;
                            newObject.GetComponent<Buildings.BuildingControl>().Building = false;
                            Manager.Instance.AddtoMines(newObject);
                            break;

                    }
                    Manager.Instance.AddtoBuildings(newObject);
                    if(building.UpgradeFinish != null)
                    {
                        System.DateTime upgradeFinish = new System.DateTime(building.UpgradeFinish[0], building.UpgradeFinish[1], building.UpgradeFinish[2], building.UpgradeFinish[3], building.UpgradeFinish[4], building.UpgradeFinish[5]);
                        System.DateTime upgradeStart = new System.DateTime(building.UpgradeStart[0], building.UpgradeStart[1], building.UpgradeStart[2], building.UpgradeStart[3], building.UpgradeStart[4], building.UpgradeStart[5]);
                        newObject.GetComponent<Buildings.BuildingUpgrade>().SetUpgradeFinish(upgradeFinish);
                        newObject.GetComponent<Buildings.BuildingUpgrade>().SetUpgradeStart(upgradeStart);
                        Manager.Instance.AddToUpgrades(newObject);
                        newObject.GetComponent<Buildings.BuildingUpgrade>().Upgrade(newObject, false);
                    }
                }
                foreach (SaveSystem.WallSaveData wallSaveData in data.wallSaveData)
                {
                    Vector3 pos = new Vector3(wallSaveData.position[0], wallSaveData.position[1], wallSaveData.position[2]);
                    GameObject newWall = null;
                    newWall = Instantiate(wall);
                    newWall.transform.position = pos;
                    newWall.GetComponent<Buildings.GridControl>().Building = false;
                    newWall.GetComponent<Buildings.BuildingControl>().Building = false;
                    Manager.Instance.AddToWalls(newWall);
                } 

                
            }
        }

        private void OnApplicationQuit()
        {
            //Debug.Log("Closing");
            SaveSystem.Saving.SaveData(ResourceManager.Instance, Manager.Instance);
        }
    }
}