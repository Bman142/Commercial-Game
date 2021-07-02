using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Buildings
{
    public class GridControl : MonoBehaviour
    {
        Transform centrePoint;                                  // Centre Point of the Object
        new Camera camera;                                      // Empty Camera Object
        [SerializeField] float snapFactor;                      // How many units to snap to(1, 10, 20, ect)
        private Vector3 point;                                  // Mouse Position in world space
        [SerializeField] bool building = true;                  // Is the building being built or not?
        public bool Building { set { building = value; } }
        Vector3 mousePos = Vector3.zero;                        // Mouse Position in Screen Space
        // Start is called before the first frame update
        void Start()
        {
            camera = Camera.main;
            centrePoint = this.transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (building)
            {
                mousePos.x = Input.mousePosition.x;
                mousePos.y = Input.mousePosition.y;

                RaycastHit hit;
                Physics.Raycast(camera.ScreenPointToRay(mousePos), out hit);
                point = hit.point;
                point.y = 10;

                centrePoint.position = new Vector3(Mathf.Round(point.x / snapFactor) * snapFactor, point.y, Mathf.Round(point.z / snapFactor) * snapFactor);
            }
            
        }
        
    }
}