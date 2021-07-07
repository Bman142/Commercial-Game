using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace CubeCastle.Upgrades
{
    public class UpgradeText : MonoBehaviour
    {
        [SerializeField]
        Buildings.BuildingData.BuildingStyle buildingStyle;             // Type of Building
        GameObject Building;                                            // Reference to the building that was clicked on
        int currentLevel;                                               // Building Level
        [SerializeField] TextMeshProUGUI currentLevelText;              // Text that displays the current level
        [SerializeField] Color highlightColour;                         // Colour the building will be tinted with on selection
        Color holding;                                                  // place to hold existing colour of building
        [SerializeField] TextMeshProUGUI currentResourceText;           // text that displays the current amount of resources in the building
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
            if (!Building.GetComponent<Buildings.BuildingUpgrade>().UpgradeStatus)
            {
                Building.GetComponent<Buildings.BuildingUpgrade>().Upgrade(Building);
                CloseUpgradeMenu();
            }
        }
        public void CloseUpgradeMenu()
        {
            Building.GetComponent<Renderer>().material.color = holding;
            Destroy(this.gameObject);
        }

        public void CollectResources()
        {
            switch (buildingStyle)                                      // Send Resources to the correct variable in resource manager
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