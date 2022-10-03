// Add System.IO to work with files!

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


public static class SaveManager
{
    // Create a field for the save file.
    private static string dataPath = Application.persistentDataPath + "/savedata.json";


    // Create a GameData field.
    public static SaveData SaveData;
    
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

    public static float GetValue(string key)
    {
        if (SaveData != null )
        {
            if (SaveData.datas.ContainsKey(key))
            {
                return SaveData.datas[key];
            }
        }

        return 0;
    }
    
    
    public static void Save(string key,float value)
    {
        if (SaveData.datas.ContainsKey(key))
        {
            SaveData.datas[key] = value;
        }
        else
        {
            SaveData.datas.Add(key,value);
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