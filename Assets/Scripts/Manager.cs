using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CubeCastle
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] List<GameObject> buildings;
        [SerializeField] List<GameObject> houses;
        [SerializeField] List<GameObject> mills;
        [SerializeField] List<GameObject> mines;


        static Manager instance;
        public static Manager Instance { get { return instance; } }


        [SerializeField] TextMeshProUGUI notification;
        public TextMeshProUGUI Notification { get { return notification; } }

        bool buildingMode;
        public bool BuildingMode { get { return buildingMode; } set { buildingMode = value; } }

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
            StartUpCheck();
        }
        void StartUpCheck()
        {
            if(ResourceManager.Instance.GetAvailablePopulation != 5)
            {
                ResourceManager.Instance.AddPopulation(5);
            }
            if(houses.Count == 0)
            {
                Debug.LogError("Starting House Not Added to Houses List");
            }
            if(buildings.Count == 0)
            {
                Debug.LogError("Starting House Not Added to Buildings List");
            }
        }
        
        public void AddtoHouses(GameObject house)
        {
            houses.Add(house);
            ResourceManager.Instance.AddPopulation(house.GetComponent<BuildingData>().ResourceMax);
        }
        public void AddtoBuildings(GameObject building)
        {
            buildings.Add(building);
        }
        public void AddtoMills(GameObject mill)
        {
            mills.Add(mill);
            ResourceManager.Instance.IncreaseMaxWood = mill.GetComponent<BuildingData>().ResourceMax;
        }
        public void AddtoMines(GameObject mine)
        {
            mines.Add(mine);
            ResourceManager.Instance.IncreaseMaxGold = mine.GetComponent<BuildingData>().ResourceMax;
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
        

        public IEnumerator TextFade(string text)
        {
            notification.text = text;
            yield return new WaitForSeconds(2);
            notification.text = "";
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
                    
                }
                timeOfNextGather += timeBetweenGathers;
            }
            

        }

      
    }
}