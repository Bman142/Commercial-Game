using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CubeCastle
{
    public class UpdateResource : MonoBehaviour
    {
        TextMeshProUGUI stat;
        enum Resources { Wood, Population, Gold}
        [SerializeField] Resources resource;
        private void Start()
        {
            stat = this.GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            switch (resource)
            {
                case Resources.Population:
                    stat.text = "Population: " + ResourceManager.Instance.GetAvaliblePopulation.ToString();
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