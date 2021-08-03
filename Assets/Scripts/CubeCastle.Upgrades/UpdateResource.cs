using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CubeCastle.Upgrades
{
    public class UpdateResource : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI woodStat, avalStat, totalStat, goldStat, premiumStat; // Text that displays the resource value
                                         
        private void Start()
        {
            InvokeRepeating(nameof(ResourceUpdater), 0, 0.1f);
        }

        

        void ResourceUpdater()
        {
            avalStat.text = "Avalible Population: " + Managers.ResourceManager.Instance.GetAvailablePopulation.ToString();
                   
            totalStat.text = "Total Population: " + Managers.ResourceManager.Instance.GetTotalPopulation.ToString();
                   
            woodStat.text = "Wood: " + Managers.ResourceManager.Instance.GetStoredWood.ToString();

            goldStat.text = "Gold: " + Managers.ResourceManager.Instance.GetStoredGold.ToString();

            premiumStat.text = "Gems: " + Managers.Store.StoreManager.Instance.PremiumCurrency.ToString();
                    
            
        }
    }
}