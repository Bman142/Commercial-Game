using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


//TODO: Add Analytics Events
namespace CubeCastle.Buildings
{
    public class BuildingControl : MonoBehaviour
    {
        [SerializeField] bool building = true;
        [SerializeField] BuildingData.BuildingStyle buildingType;
        
        Menus.InstansiateButton button;
        public Menus.InstansiateButton Button { get { return button; } set { button = value; } }

        public bool Building { set { building = value; } }
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating(nameof(BuildingController), 0, 0.1f);
        }

        

        void BuildingController()
        {
            if (building)                                                                                // Is the building still being built?
            {
                if (Input.touchCount > 0)                                                                // Is left mouse button down?
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (!Managers.Manager.Instance.CheckBuildingPositions(this.gameObject))
                        {                     // Check if the building overlaps another

                            if (!Managers.Manager.Instance.CheckWallPositions(this.gameObject))
                            {
                                switch (buildingType)              // Subtract the right amount of resources dependant on building
                                {

                                    case BuildingData.BuildingStyle.House:
                                        if (Managers.ResourceManager.Instance.GetStoredGold >= 20)
                                        {
                                            Managers.Manager.Instance.AddtoHouses(this.gameObject);
                                            Managers.ResourceManager.Instance.TakeGold(20);
                                            Analytics.CustomEvent("Build House");
                                            SetBuilding();
                                        }
                                        else
                                        {
                                            StartCoroutine(Managers.Manager.Instance.TextFade("Insufficent Resources"));
                                        }
                                        break;
                                    case BuildingData.BuildingStyle.Mill:
                                        if (Managers.ResourceManager.Instance.GetAvailablePopulation >= 5)
                                        {
                                            Managers.Manager.Instance.AddtoMills(this.gameObject);
                                            Managers.ResourceManager.Instance.TakePopulation(5);
                                            Analytics.CustomEvent("Build Mill");
                                            SetBuilding();
                                        }
                                        else
                                        {
                                            StartCoroutine(Managers.Manager.Instance.TextFade("Insufficent Population"));
                                        }
                                        break;
                                    case BuildingData.BuildingStyle.Mine:
                                        if (Managers.ResourceManager.Instance.GetStoredWood >= 20)
                                        {
                                            Managers.Manager.Instance.AddtoMines(this.gameObject);
                                            Managers.ResourceManager.Instance.TakeWood(20);
                                            Analytics.CustomEvent("Build Mine");
                                            SetBuilding();
                                        }
                                        else
                                        {
                                            StartCoroutine(Managers.Manager.Instance.TextFade("Insufficent Resources"));
                                        }
                                        break;
                                    case BuildingData.BuildingStyle.Wall:
                                        Managers.Manager.Instance.AddToWalls(this.gameObject);
                                        Analytics.CustomEvent("Build Wall");
                                        SetBuilding();
                                        break;
                                }
                            }
                            else
                            {
                                StartCoroutine(Managers.Manager.Instance.TextFade(this.gameObject.name + " Overlaps Existing Building"));

                            }
                        }
                        else
                        {
                            StartCoroutine(Managers.Manager.Instance.TextFade(this.gameObject.name + " Overlaps Existing Building"));

                        }
                    }
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    if (building)
                    {
                        Destroy(this.gameObject);
                        building = false;
                        this.GetComponent<GridControl>().Building = false;
                        Managers.Manager.Instance.BuildingMode = false;
                    }
                }
                void SetBuilding()                                                                              // Set Various building variables to the appropriate values
                {
                    button.GetComponent<Menus.InstansiateButton>().NullObject();
                    building = false;
                    this.GetComponent<GridControl>().Building = false;
                    Managers.Manager.Instance.BuildingMode = false;
                    Managers.Manager.Instance.AddtoBuildings(this.gameObject);
                }
            }
        }
    }
}
