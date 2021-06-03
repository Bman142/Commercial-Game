using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle
{
    public class BuildingControl : MonoBehaviour
    {
        [SerializeField] bool building = true;
        [SerializeField] BuildingData.BuildingStyle buildingType;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (building)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!Manager.Instance.CheckBuildingPositions(this.gameObject))
                    {
                        switch (buildingType)
                        {
                            
                            case BuildingData.BuildingStyle.House:
                                if (Manager.Instance.GetStoredGold >= 20)
                                {
                                    Manager.Instance.AddtoHouses(this.gameObject);
                                    Manager.Instance.TakeGold(20);
                                    SetBuilding();
                                }
                                else
                                {
                                    StartCoroutine(Manager.Instance.TextFade("Insufficent Resources"));
                                }
                                break;
                            case BuildingData.BuildingStyle.Mill:
                                if (Manager.Instance.GetPopulation >= 5)
                                {
                                    Manager.Instance.AddtoMills(this.gameObject);
                                    Manager.Instance.TakePopulation(5);
                                    SetBuilding();
                                }
                                else
                                {
                                    StartCoroutine(Manager.Instance.TextFade("Insufficent Population"));
                                }
                                break;
                            case BuildingData.BuildingStyle.Mine:
                                if (Manager.Instance.GetStoredWood >= 20)
                                {
                                    Manager.Instance.AddtoMines(this.gameObject);
                                    Manager.Instance.TakeWood(20);
                                    SetBuilding();
                                }
                                else
                                {
                                    StartCoroutine(Manager.Instance.TextFade("Insufficent Resources"));
                                }
                                break;
                        }

                    }
                    else
                    {
                        StartCoroutine(Manager.Instance.TextFade(this.gameObject.name + " Overlaps existing building"));

                    }
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    if (building)
                    {
                        Destroy(this.gameObject);
                    }
                }
                void SetBuilding()
                {
                    building = false;
                    this.GetComponent<GridControl>().Building = false;
                    Manager.Instance.AddtoBuildings(this.gameObject);
                }
            }

        }
    }
}