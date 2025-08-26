using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadGamePreferencesDataJSON : ISaveLoadGamePreferencesData
{
    public GamePreferencesData LoadGamePreferencesData(string location)
    {
        string json = "";
        StreamReader sr = new StreamReader(location);
        json = sr.ReadToEnd();
        sr.Close();

        return JsonUtility.FromJson<GamePreferencesData>(json);
    }

    public void SaveGamePreferencesData(GamePreferencesData gpd, string location)
    {
        string json = JsonUtility.ToJson(gpd);

        StreamWriter sw = new StreamWriter(location);
        sw.Write(json);
        sw.Close();
    }
}
