using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CubeCastle.Upgrades
{
    public class UpgradeText : MonoBehaviour
    {
        [SerializeField]
        Buildings.BuildingData.BuildingStyle buildingStyle;
        GameObject Building;
        int currentLevel;
        [SerializeField] TextMeshProUGUI currentLevelText;
        [SerializeField] Color highlightColour;
        Color holding;
        [SerializeField] TextMeshProUGUI currentResourceText;

        public void OnInstansiate(GameObject building)
        {
            Building = building;
            currentLevel = Building.GetComponent<Buildings.BuildingData>().BuildingLevel;
            currentLevelText.text = "Level: " + currentLevel.ToString();
            holding = Building.GetComponent<Renderer>().material.color;
            Building.GetComponent<Renderer>().material.color = highlightColour;
            currentResourceText.text = currentResourceText.text +  Building.GetComponent<Buildings.BuildingData>().ResourceCurrent.ToString();
        }

        public void Upgrade()
        {
            Building.GetComponent<Buildings.BuildingData>().IncreaseBuildingLevel();
            CloseUpgradeMenu();
        }
        public void CloseUpgradeMenu()
        {
            Building.GetComponent<Renderer>().material.color = holding;
            Destroy(this.gameObject);
        }

        public void CollectResources()
        {
            switch (buildingStyle)
            {
                case Buildings.BuildingData.BuildingStyle.Mill:
                    Managers.ResourceManager.Instance.AddWood(Building.GetComponent<Buildings.BuildingData>().GatherCurrentResource());
                    break;

                case Buildings.BuildingData.BuildingStyle.Mine:
                    Managers.ResourceManager.Instance.AddGold(Building.GetComponent<Buildings.BuildingData>().GatherCurrentResource());
                    break;

                case Buildings.BuildingData.BuildingStyle.House:
                    break;
            }
            CloseUpgradeMenu();
        }

        
    }
}