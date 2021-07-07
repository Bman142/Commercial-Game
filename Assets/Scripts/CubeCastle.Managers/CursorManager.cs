using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubeCastle.Managers
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] float rotationSpeed = 10;  // Speed of Camera Rotation
        float MaxToClamp = 10;                      // Max Zoom out
        float ZoomAmount = 0;                       // Current Zoom Level
        [SerializeField] float speed = 10f;         // Zoom Speed
        new Camera camera;                          // Camera Object
        Vector3 mousePos = Vector3.zero;
        // Start is called before the first frame update
        void Start()
        {
            camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
            if (Input.GetMouseButtonDown(0) && !Manager.Instance.BuildingMode)
            {
                /*try
                {
                    Upgrades.UpgradeText upgradeText = FindObjectOfType<Upgrades.UpgradeText>();
                    Debug.Log(upgradeText);
                }
                catch
                {
                    Debug.Log("Catch");
                    Physics.Raycast(camera.ScreenPointToRay(mousePos), out RaycastHit hit);
                    
                    hit.collider.GetComponent<Buildings.BuildingUpgrade>().Popup(mousePos, hit.collider.GetComponent<Buildings.BuildingData>().BuildingType);
                }*/
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Upgrades.UpgradeText upgradeText = FindObjectOfType<Upgrades.UpgradeText>();
                    if (upgradeText == null)
                    {
                        Physics.Raycast(camera.ScreenPointToRay(mousePos), out RaycastHit hit);
                        if (hit.collider.GetComponent<Buildings.BuildingUpgrade>() != null)
                        {
                            hit.collider.GetComponent<Buildings.BuildingUpgrade>().Popup(mousePos, hit.collider.GetComponent<Buildings.BuildingData>().BuildingType);
                        }
                    }
                }



            }
            if (Input.GetMouseButton(2))
            {
                if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") < 0)   // Move the mouse on Right Mouse button held Down
                {
                    camera.transform.position += new Vector3(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                               0.0f, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
                }

                else if (Input.GetAxis("Mouse X") < 0)
                {
                    camera.transform.position += new Vector3(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                               0.0f, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
                }
            }

            //Camera Zoom Use FOV


            ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
            ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
            var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));
            camera.transform.Translate(0, 0, translate * rotationSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));

        }
    }
}