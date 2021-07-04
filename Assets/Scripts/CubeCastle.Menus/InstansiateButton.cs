using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Menus
{
    public class InstansiateButton : MonoBehaviour
    {
        [SerializeField] GameObject prefab;     // Object to be instansiated
        public void CreateObject()
        {
            GameObject newObject = Instantiate(prefab);
            newObject.name = newObject.name.Replace("(Clone)", ""); // Remove (Clone) from object name
            Managers.Manager.Instance.BuildingMode = true;          // Tell Manager to treat the game as building mode
        }
    }
}