// Add System.IO to work with files!

using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace GameAssets.Scripts.Misc
{
    public static class SaveManager
    {
        // Create a field for the save file.
        private static string dataPath = Application.persistentDataPath + "/gameSave.json";


        // Create a GameData field.
        private static SaveData SaveData = new SaveData();

        public static void ReadFile(Action onComplete)
        {
            // Does the file exist?
            if (File.Exists(dataPath))
            {
                // Read the entire file and save its contents.
                string fileContents = File.ReadAllText(dataPath);

                // Deserialize the JSON data 
                //  into a pattern matching the GameData class.
                SaveData = JsonConvert.DeserializeObject<SaveData>(fileContents);
            }

            onComplete?.Invoke();
        }

        public static bool GetValue(string key, out double value)
        {
            value = 0;
            if (SaveData != null)
            {
                if (SaveData.datas.ContainsKey(key))
                {
                    value = SaveData.datas[key];
                    return true;
                }
            }

            return false;
        }


        public static void Save(string key, double value)
        {
            if (SaveData.datas.ContainsKey(key))
            {
                SaveData.datas[key] = value;
            }
            else
            {
                SaveData.datas.Add(key, value);
            }

            SaveFile();
        }

        private static void SaveFile()
        {
            string json = JsonConvert.SerializeObject(SaveData);

            File.WriteAllText(dataPath, json);
            Debug.Log("File saved");
        }
    }
}