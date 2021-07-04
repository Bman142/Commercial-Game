using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CubeCastle.Buildings
{
    public class BuildingData : MonoBehaviour
    {
        public enum BuildingStyle { House, Mine, Mill, Wall}
        [SerializeField] BuildingStyle buildingType;
        public BuildingStyle BuildingType { get { return buildingType; } set { buildingType = value; } }
        [SerializeField] int buildingLevel = 1;
        public int BuildingLevel { get { return buildingLevel; } }
        [SerializeField] int resourcePerTime;                               // How many resources the building gathers per second
        public int ResourcePerTime { get { return resourcePerTime; } }
        [SerializeField] int resourceMax;                                   // Maximum amount of resources the building can hold
        public int ResourceMax { get { return resourceMax; } }
        [SerializeField] int resourceCurrent;                               // Current amount of resource the building holsd
        public int ResourceCurrent { get { return resourceCurrent; } set { resourceCurrent = value; } }
        private void Start()
        {
            
            switch (buildingType)                                           // Set variables based on what type of building it is
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

        public int GatherCurrentResource()
        {
            int tmp = resourceCurrent;
            resourceCurrent = 0;
            return tmp;
            
        }

        public void ResourceGather()
        {
            switch (buildingType)                                           // Return the correct value depending on the building
            {
                case BuildingStyle.House:
                    return;                                                 // Houses should not be able to return any new resources
                case BuildingStyle.Mill:
                    resourceCurrent += resourcePerTime;
                    if(resourceCurrent > resourceMax)
                    {
                        resourceCurrent = resourceMax;
                    }
                    break;
                case BuildingStyle.Mine:
                    resourceCurrent += resourcePerTime;
                    if (resourceCurrent > resourceMax)
                    {
                        resourceCurrent = resourceMax;
                    }
                    break;
            }
        }
    }
}