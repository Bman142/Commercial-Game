using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Managers.Store
{
    public class StoreManager : MonoBehaviour
    {
        static StoreManager instance;
        public static StoreManager Instance { get { return instance; } }
        [SerializeField] int premiumCurrency;
        public int PremiumCurrency { get { return premiumCurrency; } }
        private void Awake()
        {
            SingletonSetup(); 
        }

        void SingletonSetup() // Set singleton reference
        {
            if (instance != null)
            {
                if (instance != this)
                {
                    Destroy(this);
                }
            }
            else
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
        }
        public bool TakeCurrency(int amount, bool resourceStorageVaild)
        {
            if (!resourceStorageVaild) { return false; }
            if(premiumCurrency - amount  < 0) 
            {
                //premiumCurrency += amount;
                return false;
            }
            else
            {
                premiumCurrency -= amount;
            }
            return true;
        }

        public void AddCurrency(int amount)
        {
            premiumCurrency += amount;
        }
    }
}