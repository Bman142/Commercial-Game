using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubeCastle.Managers
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] float ROTSpeed = 10;
        float MaxToClamp = 10;
        float ZoomAmount = 0;
        [SerializeField] float speed = 10f;
        new Camera camera;
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
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Physics.Raycast(camera.ScreenPointToRay(mousePos), out RaycastHit hit);
                    hit.collider.GetComponent<Buildings.BuildingUpgrade>().Popup(mousePos, hit.collider.GetComponent<Buildings.BuildingData>().BuildingType);
                }
                
            }
            if (Input.GetMouseButton(1))
            {
                if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") < 0)
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
            camera.transform.Translate(0, 0, translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));

        }
    }
}