using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(SaveData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static SaveData Load()
    {
        if(!File.Exists(GetPath()))
        {
            SaveData empty_data = new SaveData();
            Save(empty_data);
            return empty_data;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
        SaveData data = formatter.Deserialize(fs) as SaveData;

        fs.Close();
        return data;
    }
    private static string GetPath()
    {
        return Application.persistentDataPath + "/data.qnd";
    }
}
