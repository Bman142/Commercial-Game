using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CubeCastle.SaveSystem
{
    public static class Saving
    {
        public static void SaveData(Managers.ResourceManager resourceManager, Managers.Manager manager)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/gameData.bin";
            FileStream stream = new FileStream(path, FileMode.Create);

            GameData data = new GameData(resourceManager, manager);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static GameData LoadData()
        {
            string path = Application.persistentDataPath + "/gameData.bin";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                GameData gameData = formatter.Deserialize(stream) as GameData;
                stream.Close();
                return gameData;
            }
            else
            {
                Debug.Log("Save File Not Found in: \"" + path + "\". Starting New Level");
                return null;
            }
        }
    }

}