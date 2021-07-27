using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCastle.Menus
{
    public class MenuSelector : MonoBehaviour
    {
        [SerializeField] GameObject productionMenu, defenceMenu, productionMenuButton, defenceMenuButton;

        void Awake()
        {
            StartUpCheck(); 
        }
        void StartUpCheck()
        {
            defenceMenu.GetComponent<Canvas>().enabled = false;
            productionMenu.GetComponent<Canvas>().enabled = false;
            productionMenuButton.SetActive(true);
            defenceMenuButton.SetActive(true);
        }
        public void LoadDefenceMenu()
        {
            defenceMenu.GetComponent<Canvas>().enabled = true;
            productionMenuButton.SetActive(false);
            defenceMenuButton.SetActive(false);
        }

        public void CloseDefenceMenu()
        {
            defenceMenu.GetComponent<Canvas>().enabled = false;
            productionMenuButton.SetActive(true);
            defenceMenuButton.SetActive(true);
        }

        public void LoadProductionMenu()
        {
            productionMenu.GetComponent<Canvas>().enabled = true;
            productionMenuButton.SetActive(false);
            defenceMenuButton.SetActive(false);
        }

        public void CloseProductionMenu()
        {
            productionMenu.GetComponent<Canvas>().enabled = false;
            productionMenuButton.SetActive(true);
            defenceMenuButton.SetActive(true);
        }

    }
}