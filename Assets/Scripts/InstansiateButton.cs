using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstansiateButton : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    public void CreateObject()
    {
        GameObject newObject = Instantiate(prefab);
        newObject.name
        
    }
}
