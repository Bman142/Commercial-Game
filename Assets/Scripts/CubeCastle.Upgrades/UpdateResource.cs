using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CubeCastle.Upgrades
{
    public class UpdateResource : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI woodStat1, woodStat2, avalStat1, avalStat2, totalStat1, totalStat2, goldStat1, goldStat2, premiumStat1, premiumStat2; // Text that displays the resource value
                                         
        private void Start()
        {
            InvokeRepeating(nameof(ResourceUpdater), 0, 0.1f);
        }

        

        void ResourceUpdater()
        {
            avalStat1.text = "Avalible Population: " + Managers.ResourceManager.Instance.GetAvailablePopulation.ToString();

            avalStat2.text = "Avalible Population: " + Managers.ResourceManager.Instance.GetAvailablePopulation.ToString();

            totalStat1.text = "Total Population: " + Managers.ResourceManager.Instance.GetTotalPopulation.ToString();
            totalStat2.text = "Total Population: " + Managers.ResourceManager.Instance.GetTotalPopulation.ToString();
                   
            woodStat1.text = "Wood: " + Managers.ResourceManager.Instance.GetStoredWood.ToString();
            woodStat2.text = "Wood: " + Managers.ResourceManager.Instance.GetStoredWood.ToString();

            goldStat1.text = "Gold: " + Managers.ResourceManager.Instance.GetStoredGold.ToString();
            goldStat2.text = "Gold: " + Managers.ResourceManager.Instance.GetStoredGold.ToString();

            premiumStat1.text = "Gems: " + Managers.Store.StoreManager.Instance.PremiumCurrency.ToString();

            premiumStat2.text = "Gems: " + Managers.Store.StoreManager.Instance.PremiumCurrency.ToString();


        }
    }
}