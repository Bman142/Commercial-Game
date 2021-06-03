using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControl : MonoBehaviour
{
    Transform centrePoint;
    new Camera camera;
    [SerializeField] float snapFactor;
    private Vector3 point;
    public Vector3 Point { get { return point; } }
    bool building = true;
    Vector3 mousePos = Vector3.zero;
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
            if (Input.GetMouseButtonDown(0)) { building = false; }
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;

            RaycastHit hit;
            Physics.Raycast(camera.ScreenPointToRay(mousePos), out hit);
            point = hit.point;
            point.y = 5;

            centrePoint.position = new Vector3(Mathf.Round(point.x/snapFactor)*snapFactor, point.y, Mathf.Round(point.z/snapFactor)*snapFactor);
        }
        else 
        { }
    }
    
}
