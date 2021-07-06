using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Buildings
{
    public class BuildingUpgrade : MonoBehaviour
    {
        [SerializeField] Canvas canvas;                                                 // Reference to the world canvas
        [SerializeField] GameObject houseUpgradeText, millUpgradeText, mineUpgradeText; // Text box prefabs for various building types

        private void Awake()
        {
            canvas = Managers.Manager.Instance.Canvas;                  // Find World Canvas
            
        }
        public void Popup(Vector3 mousePos, BuildingData.BuildingStyle typeOfBuilding)
        {
            GameObject newText = null;
            switch (typeOfBuilding)
            {
                case BuildingData.BuildingStyle.House:
                    newText = Instantiate(houseUpgradeText, canvas.transform);
                    break;
                case BuildingData.BuildingStyle.Mill:
                    newText = Instantiate(millUpgradeText, canvas.transform);
                    break;
                case BuildingData.BuildingStyle.Mine:
                    newText = Instantiate(mineUpgradeText, canvas.transform);
                    break;
            }
            newText.GetComponent<Upgrades.UpgradeText>().OnInstansiate(this.gameObject);
            newText.transform.position = mousePos;
        }


    }
}