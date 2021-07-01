using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Managers
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] GameObject house, mill, mine;
        private void Awake()
        {
            SaveSystem.GameData data = SaveSystem.Saving.LoadData();
            ResourceManager.Instance.SetGold(data.gold);
            ResourceManager.Instance.SetWood(data.wood);
            ResourceManager.Instance.SetAvailPop(data.availPop);
            ResourceManager.Instance.SetTotalPop(data.totalPop);

            foreach(SaveSystem.BuildingSaveData building in data.buildingSaveData)
            {
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
                        break;
                    case 1: //Mill
                        newObject = Instantiate(mill);
                        newObject.transform.position = pos;
                        newObject.GetComponent<Buildings.BuildingData>().BuildingType = Buildings.BuildingData.BuildingStyle.Mill;
                        newObject.GetComponent<Buildings.BuildingData>().ResourceCurrent = building.resourceAmount;
                        newObject.GetComponent<Buildings.GridControl>().Building = false;
                        break;

                    case 2: //Mine
                        newObject = Instantiate(mine);
                        newObject.transform.position = pos;
                        newObject.GetComponent<Buildings.BuildingData>().BuildingType = Buildings.BuildingData.BuildingStyle.Mine;
                        newObject.GetComponent<Buildings.BuildingData>().ResourceCurrent = building.resourceAmount;
                        newObject.GetComponent<Buildings.GridControl>().Building = false;
                        break;
                }
            }
        }

        private void OnApplicationQuit()
        {
            Debug.Log("Closing");
            SaveSystem.Saving.SaveData(ResourceManager.Instance, Manager.Instance);
        }
    }
}