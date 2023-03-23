using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad
{
    public static string SaveData(Inventory inv)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.data";
        Debug.Log(path);

        FileStream stream = new FileStream(path, FileMode.Create);


        formatter.Serialize(stream, inv);
        stream.Close();
        return path;
    }

    public static Inventory LoadData()
    {
        string path = Application.persistentDataPath + "/save.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Inventory data = formatter.Deserialize(stream) as Inventory;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }
}   