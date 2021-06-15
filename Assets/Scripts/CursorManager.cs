using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubeCastle
{
    public class CursorManager : MonoBehaviour
    {
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
                    hit.collider.GetComponent<BuildingUpgrade>().Popup(mousePos, hit.collider.GetComponent<BuildingData>().BuildingType);
                }
                
            }
            
            
        }
    }
}