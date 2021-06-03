using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] List<GameObject> cubes;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void AddtoCubes(GameObject cube)
    {
        cubes.Add(cube);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + Camera.main.pixelWidth + ":" + Camera.main.pixelHeight);
        GUILayout.Label("Mouse position: " + Input.mousePosition);
        GUILayout.EndArea();
    }
}
