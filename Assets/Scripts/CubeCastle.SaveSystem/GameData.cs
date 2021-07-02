using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.SaveSystem {
    [System.Serializable]
    public struct BuildingSaveData  // Data of buildings in a format that can be saved to binary disk
    {
        public int buildingType;
        public int[] position;
        public int resourceAmount;
        

        public BuildingSaveData(Buildings.BuildingData.BuildingStyle buildingStyle, Vector3 positionInput, int resourceAmountInput)
        {
            position = new int[3];
            switch (buildingStyle)
            {
                case Buildings.BuildingData.BuildingStyle.House:
                    buildingType = 0;
                    break;

                case Buildings.BuildingData.BuildingStyle.Mill:
                    buildingType = 1;
                    break;

                case Buildings.BuildingData.BuildingStyle.Mine:
                    buildingType = 2;
                    break;

                default:
                    buildingType = -1;
                    break;
            }

            position[0] = (int)positionInput.x;
            position[1] = (int)positionInput.y;
            position[2] = (int)positionInput.z;

            resourceAmount = resourceAmountInput;

            
        }
        
    }

    [System.Serializable]
    public class GameData // Resource data to be saved to disk.
    {
        public int gold;
        public int wood;
        public int totalPop;
        public int availPop;
        public List<BuildingSaveData> buildingSaveData = new List<BuildingSaveData>();
        public int maxGold;
        public int maxWood;

    


        public GameData(Managers.ResourceManager resourceManager, Managers.Manager manager)
        {
            gold = resourceManager.GetStoredGold;
            wood = resourceManager.GetStoredWood;
            totalPop = resourceManager.GetTotalPopulation;
            availPop = resourceManager.GetAvailablePopulation;
            buildingSaveData = new List<BuildingSaveData>();
            maxGold = resourceManager.GetMaxGold();
            maxWood = resourceManager.GetMaxWood();


            List<GameObject> buildings = manager.GetBuildings();
            foreach (GameObject building in buildings)
            {
                //Debug.Log(building.GetComponent<Buildings.BuildingData>());
                buildingSaveData.Add(new BuildingSaveData(building.GetComponent<Buildings.BuildingData>().BuildingType,
                    building.transform.position, building.GetComponent<Buildings.BuildingData>().ResourceCurrent));
            }
           
            
            
        }
        
    }
}