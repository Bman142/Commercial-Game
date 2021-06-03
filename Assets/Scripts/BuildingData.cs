using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CubeCastle
{
    public class BuildingData : MonoBehaviour
    {
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

        public void ResourceGather()
        {
            switch (buildingType)
            {
                case BuildingStyle.House:
                    return;
                case BuildingStyle.Mill:
                    Manager.Instance.AddWood(resourcePerTime);
                    break;
                case BuildingStyle.Mine:
                    Manager.Instance.AddGold(resourcePerTime);
                    break;
            }
        }
    }
}