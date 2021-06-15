using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle
{
    public class InstansiateButton : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        public void CreateObject()
        {
            GameObject newObject = Instantiate(prefab);
            newObject.name = newObject.name.Replace("(Clone)", "");
            Manager.Instance.BuildingMode = true;
        }
    }
}