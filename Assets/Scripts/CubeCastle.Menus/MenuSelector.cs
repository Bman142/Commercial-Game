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
            defenceMenu.SetActive(false);
            productionMenu.SetActive(false);
            productionMenuButton.SetActive(true);
            defenceMenuButton.SetActive(true);
        }
        public void LoadDefenceMenu()
        {
            defenceMenu.SetActive(true);
            productionMenuButton.SetActive(false);
            defenceMenuButton.SetActive(false);
        }

        public void CloseDefenceMenu()
        {
            defenceMenu.SetActive(false);
            productionMenuButton.SetActive(true);
            defenceMenuButton.SetActive(true);
        }

        public void LoadProductionMenu()
        {
            productionMenu.SetActive(true);
            productionMenuButton.SetActive(false);
            defenceMenuButton.SetActive(false);
        }

        public void CloseProductionMenu()
        {
            productionMenu.SetActive(false);
            productionMenuButton.SetActive(true);
            defenceMenuButton.SetActive(true);
        }

    }
}