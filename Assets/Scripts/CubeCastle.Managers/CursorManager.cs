using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubeCastle.Managers
{
    public class CursorManager : MonoBehaviour
    {
        //[SerializeField] float rotationSpeed = 10;  // Speed of Camera Rotation
        //float MaxToClamp = 10;                      // Max Zoom out
        //float ZoomAmount = 0;                       // Current Zoom Level
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
            if (!Manager.Instance.BuildingMode)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:

                            mousePos = touch.position;
                            Upgrades.UpgradeText upgradeText = FindObjectOfType<Upgrades.UpgradeText>();
                            if (upgradeText == null)
                            {
                                Physics.Raycast(camera.ScreenPointToRay(mousePos), out RaycastHit hit);
                                if (hit.collider.GetComponent<Buildings.BuildingUpgrade>() != null)
                                {
                                    hit.collider.GetComponent<Buildings.BuildingUpgrade>().Popup(mousePos, hit.collider.GetComponent<Buildings.BuildingData>().BuildingType);
                                }
                            }

                            break;

                        case TouchPhase.Moved:
                            camera.transform.position += new Vector3(-touch.deltaPosition.x * Time.deltaTime * speed,
                                                   0.0f, -touch.deltaPosition.y * Time.deltaTime * speed);
                            break;

                    }
                }
            }
        }
    }
}