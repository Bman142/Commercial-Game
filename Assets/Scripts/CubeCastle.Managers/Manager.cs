using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

namespace CubeCastle.Managers
{
    public class Manager : MonoBehaviour
    {
        #region Variables
        [SerializeField] List<GameObject> buildings, houses, mills, mines, walls, upgrades;  // Lists of buildings for resource calculations
        [SerializeField] bool deleteSaveData;
        

        static Manager instance;                                            // Singleton Reference to the Manager
        public static Manager Instance { get { return instance; } }


        [SerializeField] TextMeshProUGUI notification1;                      // Text box used for notifications
		[SerializeField] TextMeshProUGUI notification2;
        

		[SerializeField] bool buildingMode = false;                                          // Wether the game should be treated in building mode or not
        public bool BuildingMode { get { return buildingMode; } set { buildingMode = value; } }

        [SerializeField] Canvas canvas;
        public Canvas Canvas { get { return canvas; } }

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
            InvokeRepeating(nameof(ResourceTimer), 0, 0.1f);
        }
        void StartUpCheck() // Ensure starting variables are set correctly
        {
            
            
                
                if (ResourceManager.Instance.GetAvailablePopulation != 5) //TODO: fix to work with save mechanics
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

        public void AddToUpgrades(GameObject objects)
        {
            upgrades.Add(objects);
        }

        public void RemoveFromUpgrades(GameObject objects)
        {
            upgrades.Remove(objects);
        }
        #endregion
        public bool CheckBuildingPositions(GameObject building)
        {
            foreach (GameObject test in buildings)
            {
                if (test.GetComponent<BoxCollider>().bounds.Contains(building.transform.position))
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
                if(test.GetComponent<BoxCollider>().bounds.Contains(wall.transform.position))
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

        public List<GameObject> GetUpgrades()
        {
            return upgrades;
        }

        public bool isUpgrading(GameObject test)
        {
            if(upgrades.Contains(test))
            {
                return true;
            }
            else { return false; }
        }
        public IEnumerator TextFade(string text)
        {
            notification1.text = text;
            notification2.text = text;
            yield return new WaitForSeconds(2f);
            notification1.text = "";
            notification2.text = "";
        }


        

        void ResourceTimer()
        {
            timer += Time.deltaTime;
            if (timer > timeOfNextGather)
            {
                foreach (GameObject building in buildings)
                {
                    building.GetComponent<Buildings.BuildingData>().ResourceGather();

                }
                timeOfNextGather += timeBetweenGathers;
            }
        }

      
    }
}