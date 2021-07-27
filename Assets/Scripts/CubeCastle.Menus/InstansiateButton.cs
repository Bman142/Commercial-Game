using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Menus
{
    public class InstansiateButton : MonoBehaviour
    {
        [SerializeField] GameObject prefab;     // Object to be instansiated
        GameObject newObject = null;
        public void CreateObject()
        {
            if (newObject == null) { 
                newObject = Instantiate(prefab);
                newObject.name = newObject.name.Replace("(Clone)", ""); // Remove (Clone) from object name
                Managers.Manager.Instance.BuildingMode = true;          // Tell Manager to treat the game as building mode
                newObject.GetComponent<Buildings.BuildingControl>().Button = this;
                //newObject = null;
             }
             else if (newObject != null)
            {
                Destroy(newObject);
                Managers.Manager.Instance.BuildingMode = false;
                newObject = null;

            }
        }

        public void NullObject()
        {
            newObject = null;
        }
    }
}