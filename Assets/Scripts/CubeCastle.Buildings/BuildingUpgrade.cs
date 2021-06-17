using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CubeCastle.Buildings
{
    public class BuildingUpgrade : MonoBehaviour
    {
        [SerializeField] Canvas canvas;
        [SerializeField] GameObject houseUpgradeText;
        [SerializeField] GameObject millUpgradeText;
        [SerializeField] GameObject mineUpgradeText;

        private void Awake()
        {
            canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
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
            newText.GetComponent<Upgrades.UpgradeText>().SetBuilding(this.gameObject);
            newText.transform.position = mousePos;
        }


    }
}