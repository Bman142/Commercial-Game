using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubeCastle {
    public class UpgradeText : MonoBehaviour
    {
        GameObject Building;
        public void SetBuilding(GameObject building)
        {
            Building = building;
        }

        public void Upgrade()
        {
            Debug.Log("building",Building);
            Building.GetComponent<BuildingData>().IncreaseBuildingLevel();
            Destroy(this.gameObject);
        }
    }
}