using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CubeCastle.Managers
{
    public class Manager : MonoBehaviour
    {
        #region Variables
        [SerializeField] List<GameObject> buildings, houses, mills, mines, walls;  // Lists of buildings for resource calculations
            

        static Manager instance;                                            // Singleton Reference to the Manager
        public static Manager Instance { get { return instance; } }


        [SerializeField] TextMeshProUGUI notification;                      // Text box used for notifications
        public TextMeshProUGUI Notification { get { return notification; } }

        bool buildingMode = false;                                          // Wether the game should be treated in building mode or not
        public bool BuildingMode { get { return buildingMode; } set { buildingMode = value; } }

        float timeBetweenGathers = 1f;                                      // How Often to collect resources
        float timeOfNextGather;

        float timer;
        #endregion
        #region Start Functions
        void Awake()
        {
            SingletonSetup();
            //instance = instance != null ? instance != this ? Destroy(this.gameObject) : instance = null :  instance = this;

            
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
        // Start is called before the first frame update
        void Start()
        {
            StartUpCheck();
        }
        void StartUpCheck() // Ensure starting variables are set correctly
        {
            if(ResourceManager.Instance.GetAvailablePopulation != 5) //TODO: fix to work with save mechanics
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
        #endregion
        #region Add To Lists
        public void AddtoHouses(GameObject house)
        {
            houses.Add(house);
            ResourceManager.Instance.AddPopulation(house.GetComponent<Buildings.BuildingData>().ResourceMax);
        }
        public void AddtoBuildings(GameObject building)
        {
            buildings.Add(building);
        }
        public void AddtoMills(GameObject mill)
        {
            mills.Add(mill);
            ResourceManager.Instance.IncreaseMaxWood = mill.GetComponent<Buildings.BuildingData>().ResourceMax;
        }
        public void AddtoMines(GameObject mine)
        {
            mines.Add(mine);
            ResourceManager.Instance.IncreaseMaxGold = mine.GetComponent<Buildings.BuildingData>().ResourceMax;
        }
        public void AddToWalls(GameObject wall)
        {
            walls.Add(wall);
        }
        #endregion
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

        public bool CheckWallPositions(GameObject wall)
        {
            foreach(GameObject test in walls)
            {
                if(wall.transform.position == test.transform.position)
                {
                    return true;
                }
            }
            return false;
        }
        public List<GameObject> GetWalls()
        {
            return walls;
        }

        public void ShutDown()
        {
            Application.Quit();
        }
        
        public List<GameObject> GetBuildings()
        {
            return buildings;
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
                    building.GetComponent<Buildings.BuildingData>().ResourceGather();
                    
                }
                timeOfNextGather += timeBetweenGathers;
            }
            

        }

      
    }
}