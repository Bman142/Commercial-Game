using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CubeCastle.Buildings
{
    public class BuildingData : MonoBehaviour
    {

        [SerializeField] Mesh level1Mesh, level2Mesh;
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

        [SerializeField] GameObject Popup;
        GameObject popup = null;

        MeshFilter r;
        private void Start()
        {
            r = this.GetComponent<MeshFilter>();

            switch (buildingLevel)
            {
                case 1:
                    r.mesh = level1Mesh;
                    break;
                case 2:
                    r.mesh = level2Mesh;
                    break;
            }
            

            switch (buildingType)                                           // Set variables based on what type of building it is
            {
                //TODO: Check Save System Compatability
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
            if(buildingLevel == 3) { return; }

            switch (buildingType)
            {
                case BuildingStyle.House:
                    Managers.ResourceManager.Instance.AddPopulation(resourceMax);
                    break;
                case BuildingStyle.Mill:
                    Managers.ResourceManager.Instance.IncreaseMaxWood = resourceMax;
                    break;
                case BuildingStyle.Mine:
                    Managers.ResourceManager.Instance.IncreaseMaxGold = resourceMax;
                    break;
            }
            buildingLevel += 1;
            resourceMax += resourceMax;
            resourcePerTime += resourcePerTime;
            switch (buildingLevel)
            {
                case 1:
                    r.mesh = level1Mesh;
                    break;
                case 2:
                    r.mesh = level2Mesh;
                    break;
            }

            /* Future Plans:
             * Once I have access to the new models for other levels
             * I will replace this code with code to instansiate a new version of 
             * the building at the correct level using prebuilt prefabs
             *  TODO: Fix upgrade System
             */
        }

        public int GatherCurrentResource()
        {
            
            int tmp = resourceCurrent;
            resourceCurrent = 0;
            if(popup != null)
            {
                Destroy(popup);
            }
            return tmp;
            
        }

        public void ResourceGather()
        {
            if (this.GetComponent<BuildingUpgrade>().UpgradeStatus) { return; }

            switch (buildingType)                                           // Return the correct value depending on the building
            {
                case BuildingStyle.House:
                    return;                                                 // Houses should not be able to return any new resources
                case BuildingStyle.Mill:
                    resourceCurrent += resourcePerTime;
                    if(resourceCurrent > resourceMax)
                    {
                        resourceCurrent = resourceMax;
                        if (popup == null)
                        {
                            popup = Instantiate(Popup);
                            popup.transform.position = this.transform.position + new Vector3(0, 20, 0);
                            popup.transform.rotation = Camera.main.transform.rotation;
                        }
                    }
                    break;
                case BuildingStyle.Mine:
                    resourceCurrent += resourcePerTime;
                    if (resourceCurrent > resourceMax)
                    {
                        resourceCurrent = resourceMax;
                        if (popup == null)
                        {
                            popup = Instantiate(Popup);
                            popup.transform.position = this.transform.position + new Vector3(0, 12, 0);
                            popup.transform.rotation = Camera.main.transform.rotation;
                        }
                    }
                    break;
            }
        }
    }
}