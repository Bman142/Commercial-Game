using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CubeCastle.Buildings
{
    public class BuildingData : MonoBehaviour
    {
        [SerializeField] Mesh levelTwoMesh;
        public enum BuildingStyle { House, Mine, Mill}
        [SerializeField] BuildingStyle buildingType;
        public BuildingStyle BuildingType { get { return buildingType; } }
        [SerializeField] int buildingLevel = 1;
        public int BuildingLevel { get { return buildingLevel; } }
        [SerializeField] int resourcePerTime;
        public int ResourcePerTime { get { return resourcePerTime; } }
        [SerializeField] int resourceMax;
        public int ResourceMax { get { return resourceMax; } }
        [SerializeField] int resourceCurrent;
        public int ResourceCurrent { get { return resourceCurrent; } }
        private void Start()
        {
            
            switch (buildingType)
            {
                case BuildingStyle.House:
                    resourcePerTime = 0;
                    resourceMax = 5;
                    resourceCurrent = 5;
                    break;
                case BuildingStyle.Mill:
                    resourcePerTime = 5;
                    resourceMax = 100;
                    resourceCurrent = 0;
                    break;
                case BuildingStyle.Mine:
                    resourcePerTime = 5;
                    resourceMax = 100;
                    resourceCurrent = 0;
                    break;
            }
            

        }
        public void IncreaseBuildingLevel()
        {
            buildingLevel += 1;
            if(buildingLevel > 3) 
            { 
                buildingLevel = 3;
                return;
            }
            resourceMax += resourceMax;
            resourcePerTime += resourcePerTime;
            if(buildingType == BuildingStyle.House)
            {
                Managers.ResourceManager.Instance.AddPopulation(resourceMax / 2);
            }
            else if(buildingType == BuildingStyle.Mill)
            {
                Managers.ResourceManager.Instance.IncreaseMaxWood = resourceMax / 2;
            }
            else if(buildingType == BuildingStyle.Mine)
            {
                Managers.ResourceManager.Instance.IncreaseMaxGold = resourceMax / 2;
            }

            /* Future Plans:
             * Once I have access to the new models for other levels
             * I will replace this code with code to instansiate a new version of 
             * the building at the correct level using prebuilt prefabs
             *  
             */
        }
        public void ResourceGather()
        {
            switch (buildingType)
            {
                case BuildingStyle.House:
                    return;
                case BuildingStyle.Mill:
                    Managers.ResourceManager.Instance.AddWood(resourcePerTime);
                    break;
                case BuildingStyle.Mine:
                    Managers.ResourceManager.Instance.AddGold(resourcePerTime);
                    break;
            }
        }
    }
}