using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace CubeCastle
{
   
    public class DeleteSave : MonoBehaviour
    {
        public void DeleteSaveData()
        {
            File.Delete(Application.persistentDataPath + "/gameData.bin");
        }
    }
}