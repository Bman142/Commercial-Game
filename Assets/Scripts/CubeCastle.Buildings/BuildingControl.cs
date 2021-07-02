using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Buildings
{
    public class BuildingControl : MonoBehaviour
    {
        [SerializeField] bool building = true;
        [SerializeField] BuildingData.BuildingStyle buildingType;

        public bool Building { set { building = value; } }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (building)                                                                                       // Is the building still being built?
            {
                if (Input.GetMouseButtonDown(0))                                                                // Is left mouse button down?
                {
                    if (!Managers.Manager.Instance.CheckBuildingPositions(this.gameObject))                     // Check if the building overlaps another
                    {
                        switch (buildingType)                                                                   // Subtract the right amount of resources dependant on building
                        {
                            
                            case BuildingData.BuildingStyle.House:
                                if (Managers.ResourceManager.Instance.GetStoredGold >= 20)
                                {
                                    Managers.Manager.Instance.AddtoHouses(this.gameObject);
                                    Managers.ResourceManager.Instance.TakeGold(20);
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
                                    SetBuilding();
                                }
                                else
                                {
                                    StartCoroutine(Managers.Manager.Instance.TextFade("Insufficent Resources"));
                                }
                                break;
                        }

                    }
                    else
                    {
                        StartCoroutine(Managers.Manager.Instance.TextFade(this.gameObject.name + " Overlaps Existing Building"));

                    }
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    if (building)
                    {
                        Destroy(this.gameObject);
                    }
                }
                void SetBuilding()                                                                              // Set Various building variables to the appropriate values
                {
                    building = false;
                    this.GetComponent<GridControl>().Building = false;
                    Managers.Manager.Instance.BuildingMode = false;
                    Managers.Manager.Instance.AddtoBuildings(this.gameObject);
                }
            }

        }
    }
}