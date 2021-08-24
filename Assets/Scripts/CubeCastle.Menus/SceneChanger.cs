using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int buildIndexID)
    {
        SceneManager.LoadScene(buildIndexID);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

   
    
}
