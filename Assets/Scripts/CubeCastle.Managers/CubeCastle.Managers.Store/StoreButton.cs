using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Managers.Store
{
    public class StoreButton : MonoBehaviour
    {
        [SerializeField] int currencyAmount;

        public void BuyWood(int amount)
        {
            if (StoreManager.Instance.TakeCurrency(currencyAmount))
            {
                ResourceManager.Instance.AddWood(amount);
            }
            else
            {
                Debug.Log("Insufficent Funds");
            }
        }
        public void BuyGold(int amount)
        {
            if (StoreManager.Instance.TakeCurrency(currencyAmount))
            {
                ResourceManager.Instance.AddGold(amount);
            }
            else
            {
                Debug.Log("Insufficent Funds");
            }
        }

        public void BuyCurrency(int amount)
        {
            StoreManager.Instance.AddCurrency(amount);
        }
    }
}