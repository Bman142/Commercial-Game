using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Timers;

namespace CubeCastle
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] List<GameObject> buildings;
        [SerializeField] List<GameObject> houses;
        [SerializeField] List<GameObject> mills;
        [SerializeField] List<GameObject> mines;


        int Population = 5;
        int Wood;
        int Gold;

        int woodCap;
        int goldCap;

        public int GetPopulation { get { return Population; } }
        public int GetStoredWood { get { return Wood; } }
        public int GetStoredGold { get { return Gold; } }

        static Manager instance;
        public static Manager Instance { get { return instance; } }


        [SerializeField] TextMeshProUGUI notif;
        public TextMeshProUGUI Notification { get { return notif; } }


        float timeBetweenGathers = 1f;
        float timeOfNextGather;

        float timer;
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
        // Start is called before the first frame update
        void Start()
        {
            
        }

        
        public void AddtoHouses(GameObject house)
        {
            houses.Add(house);
            Population += house.GetComponent<BuildingData>().ResourceMax;
        }
        public void AddtoBuildings(GameObject building)
        {
            buildings.Add(building);
        }
        public void AddtoMills(GameObject mill)
        {
            mills.Add(mill);
            woodCap += mill.GetComponent<BuildingData>().ResourceMax;
        }
        public void AddtoMines(GameObject mine)
        {
            mines.Add(mine);
            goldCap += mine.GetComponent<BuildingData>().ResourceMax;
        }
        public bool CheckBuildingPositions(GameObject building)
        {
            foreach (GameObject test in buildings)
            {
                if (building.transform.position == test.transform.position)
                {
                    return true;
                }
            }
            return false;

        }
        

        
        public void TakePopulation(int amount)
        {
            Population -= amount;
        }
        public void TakeWood(int amount)
        {
            Wood -= amount;
        }
        public void TakeGold(int amount)
        {
            Gold -= amount;
        }

        public void AddWood(int amount)
        {
            Wood += amount;
        }
        public void AddGold(int amount)
        {
            Gold += amount;
        }

        public IEnumerator TextFade(string text)
        {
            notif.text = text;
            yield return new WaitForSeconds(2);
            notif.text = "";
        }
        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if(timer > timeOfNextGather)
            {
                foreach(GameObject building in buildings)
                {
                    building.GetComponent<BuildingData>().ResourceGather();
                    if(Wood >= woodCap)
                    {
                        Wood = woodCap;
                    }
                    if(Gold >= goldCap)
                    {
                        Gold = goldCap;
                    }
                }
                timeOfNextGather += timeBetweenGathers;
            }
            

        }

      
    }
}