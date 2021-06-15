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
                                if (ResourceManager.Instance.GetStoredGold >= 20)
                                {
                                    Manager.Instance.AddtoHouses(this.gameObject);
                                    ResourceManager.Instance.TakeGold(20);
                                    SetBuilding();
                                }
                                else
                                {
                                    StartCoroutine(Manager.Instance.TextFade("Insufficent Resources"));
                                }
                                break;
                            case BuildingData.BuildingStyle.Mill:
                                if (ResourceManager.Instance.GetAvailablePopulation >= 5)
                                {
                                    Manager.Instance.AddtoMills(this.gameObject);
                                    ResourceManager.Instance.TakePopulation(5);
                                    SetBuilding();
                                }
                                else
                                {
                                    StartCoroutine(Manager.Instance.TextFade("Insufficent Population"));
                                }
                                break;
                            case BuildingData.BuildingStyle.Mine:
                                if (ResourceManager.Instance.GetStoredWood >= 20)
                                {
                                    Manager.Instance.AddtoMines(this.gameObject);
                                    ResourceManager.Instance.TakeWood(20);
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
                        StartCoroutine(Manager.Instance.TextFade(this.gameObject.name + " Overlaps Existing Building"));

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
                    Manager.Instance.BuildingMode = false;
                    Manager.Instance.AddtoBuildings(this.gameObject);
                }
            }

        }
    }
}