using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle
{
    public class ResourceManager : MonoBehaviour
    {

        static ResourceManager instance;
        public static ResourceManager Instance { get { return instance; } }

        [SerializeField] int totalPopulation;
        [SerializeField] int avaliblePopulation;
        [SerializeField] int maxWood;
        [SerializeField] int storedWood;
        [SerializeField] int maxGold;
        [SerializeField] int storedGold;

        public int GetTotalPopulation { get { return totalPopulation; } }
        public int GetAvailablePopulation { get { return avaliblePopulation; } }
        public int GetStoredWood { get { return storedWood; } }
        public int GetStoredGold { get { return storedGold; } }

        public int IncreaseMaxWood { set { maxWood += value; } }
        public int IncreaseMaxGold { set { maxGold += value; } }

        void Awake()
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

        public void AddPopulation(int amount)
        {
            totalPopulation += amount;
            avaliblePopulation += amount;
        }

        public void AddWood(int amount)
        {
            storedWood += amount;
            if (storedWood >= maxWood) { storedWood = maxWood; }
        }

        public void AddGold(int amount)
        {
            storedGold += amount;
            if (storedGold >= maxGold) { storedGold = maxGold; }
        }

        public void TakePopulation(int amount)
        {
            avaliblePopulation -= amount;
            if (avaliblePopulation < 0) { Debug.LogError("Buffer Underflow in Avalible Population"); }
        }

        public void TakeWood(int amount)
        {
            storedWood -= amount;
            if (storedWood < 0) { Debug.LogError("Buffer Underflow in Stored Wood"); }
        }

        public void TakeGold(int amount)
        {
            storedGold -= amount;
            if (storedGold < 0) { Debug.LogError("Buffer Underflow in Stored Gold"); }
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}