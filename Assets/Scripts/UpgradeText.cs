using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CubeCastle {
    public class UpgradeText : MonoBehaviour
    {
        GameObject Building;
        int currentLevel;
        [SerializeField] TextMeshProUGUI currentLevelText;

        public void SetBuilding(GameObject building)
        {
            Building = building;
            currentLevel = Building.GetComponent<BuildingData>().BuildingLevel;
            currentLevelText.text = "Level: " + currentLevel.ToString();
            Building.GetComponent<Renderer>().material.color = Color.red;
        }

        public void Upgrade()
        {
            Building.GetComponent<BuildingData>().IncreaseBuildingLevel();
            CloseUpgradeMenu();
        }
        public void CloseUpgradeMenu()
        {
            Building.GetComponent<Renderer>().material.color = Color.white;
            Destroy(this.gameObject);
        }
    }
}