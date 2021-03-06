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
        [SerializeField] float yOffset;                         // Vertical Offset for Building Spawning
        // Start is called before the first frame update
        void Start()
        {
            camera = Camera.main;
            centrePoint = this.transform;
            InvokeRepeating(nameof(GridController), 0, 0.1f);
        }

        
        void GridController()
        {
            if (building)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    mousePos = touch.position;
                    RaycastHit hit;
                    Physics.Raycast(camera.ScreenPointToRay(mousePos), out hit);
                    point = hit.point;
                    point.y = yOffset;

                    centrePoint.position = new Vector3(Mathf.Round(point.x / snapFactor) * snapFactor, point.y, Mathf.Round(point.z / snapFactor) * snapFactor);
                }
            }
        }
        
    }
}