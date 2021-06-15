using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CubeCastle
{
    public class UpdateResource : MonoBehaviour
    {
        TextMeshProUGUI stat;
        enum Resources { Wood, PopulationAvailable, PopulationTotal, Gold}
        [SerializeField] Resources resource;
        private void Start()
        {
            stat = this.GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            switch (resource)
            {
                case Resources.PopulationAvailable:
                    stat.text = "Avalible Population: " + ResourceManager.Instance.GetAvailablePopulation.ToString();
                    break;
                case Resources.PopulationTotal:
                    stat.text = "Total Population: " + ResourceManager.Instance.GetTotalPopulation.ToString();
                    break;
                case Resources.Wood:
                    stat.text = "Wood: " + ResourceManager.Instance.GetStoredWood.ToString();
                    break;
                case Resources.Gold:
                    stat.text = "Gold: " + ResourceManager.Instance.GetStoredGold.ToString();
                    break;
            }
        }
    }
}