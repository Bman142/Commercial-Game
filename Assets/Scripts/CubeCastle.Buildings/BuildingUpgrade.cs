using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace CubeCastle.Buildings
{
    public class BuildingUpgrade : MonoBehaviour
    {
        [SerializeField] Canvas canvas;                                                 // Reference to the world canvas
        [SerializeField] GameObject houseUpgradeText, millUpgradeText, mineUpgradeText, progressBar; // Text box prefabs for various building types

        GameObject Building;
        DateTime upgradeStart = DateTime.MaxValue;
        DateTime upgradeFinish = DateTime.MaxValue;
        [SerializeField] int upgradeTime;

        GameObject slider;
        TextMeshProUGUI timeRemaining;

        bool isUpgrading;
        public bool UpgradeStatus { get { return isUpgrading; } }

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

        public void Upgrade(GameObject building, bool setBuildTime)
        {
            isUpgrading = true;
            Building = building;
            Managers.Manager.Instance.AddToUpgrades(building);
            slider = Instantiate(progressBar);
            slider.transform.position = building.transform.position + new Vector3(0, 15, 0);
            slider.transform.rotation = Camera.main.transform.rotation;
            if (setBuildTime)
            {
                upgradeStart = DateTime.UtcNow;
                upgradeFinish = upgradeStart.AddMinutes(upgradeTime);
            }
            Debug.Log(upgradeFinish);
            timeRemaining = slider.GetComponentInChildren<TextMeshProUGUI>();
            InvokeRepeating(nameof(UpgradeTimer), 0, 0.1f);
            

        }

        private void Update()
        {
            
        }

        void UpgradeTimer()
        {
            if (upgradeFinish <= DateTime.UtcNow)
            {
                this.GetComponent<BuildingData>().IncreaseBuildingLevel();
                upgradeFinish = DateTime.MaxValue;
                upgradeStart = DateTime.MaxValue;
                Destroy(slider);
                slider = null;
                isUpgrading = false;
                CancelInvoke("UpgradeTimer");
                Managers.Manager.Instance.RemoveFromUpgrades(Building);

            }
            TimeSpan tsTOFinish = upgradeFinish.Subtract(DateTime.UtcNow);
            TimeSpan tsTotal = upgradeFinish.Subtract(upgradeStart);
            float timeToFinish = (float)tsTOFinish.TotalSeconds;
            float timeMax = (float)tsTotal.TotalSeconds;
            if (slider != null)
            {
                slider.GetComponentInChildren<UnityEngine.UI.Slider>().maxValue = timeMax;
                slider.GetComponentInChildren<UnityEngine.UI.Slider>().value = timeMax - timeToFinish;
                if(tsTOFinish.Seconds < 10)
                {
                    timeRemaining.text = tsTOFinish.Minutes.ToString() + ":0" + tsTOFinish.Seconds.ToString();
                }
                else
                {
                    timeRemaining.text = tsTOFinish.Minutes.ToString() + ":" + tsTOFinish.Seconds.ToString();
                }
                
            }
        }


        public void SetUpgradeFinish(DateTime date)
        {
            upgradeFinish = date;
        }
        public DateTime GetUpgradeFinish()
        {
            return upgradeFinish;
        }

        public void SetUpgradeStart(DateTime date)
        {
            upgradeStart = date;
        }
        public DateTime GetUpgradeStart()
        {
            return upgradeStart;
        }
    }
}