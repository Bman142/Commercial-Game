using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CubeCastle.Upgrades
{
    public class UpdateResource : MonoBehaviour
    {
        TextMeshProUGUI stat;                                                   // Text that displays the resource value
        enum Resources { Wood, PopulationAvailable, PopulationTotal, Gold}      // Type of Resource to Display
        [SerializeField] Resources resource;                                    
        private void Start()
        {
            stat = this.GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            switch (resource)                                                   // Display data depending on selected resource.
            {
                case Resources.PopulationAvailable:
                    stat.text = "Avalible Population: " + Managers.ResourceManager.Instance.GetAvailablePopulation.ToString();
                    break;
                case Resources.PopulationTotal:
                    stat.text = "Total Population: " + Managers.ResourceManager.Instance.GetTotalPopulation.ToString();
                    break;
                case Resources.Wood:
                    stat.text = "Wood: " + Managers.ResourceManager.Instance.GetStoredWood.ToString();
                    break;
                case Resources.Gold:
                    stat.text = "Gold: " + Managers.ResourceManager.Instance.GetStoredGold.ToString();
                    break;
            }
        }
    }
}