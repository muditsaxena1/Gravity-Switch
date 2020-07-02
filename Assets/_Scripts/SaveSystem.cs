using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/GarvitySwitchData.dat";

    public static void SaveData(LoadSaveManager loadSaveManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        DataFormat data = new DataFormat(loadSaveManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataFormat LoadData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataFormat data = formatter.Deserialize(stream) as DataFormat;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("Data file doesn't exists in " + path);
            return null;
        }
    }
}
