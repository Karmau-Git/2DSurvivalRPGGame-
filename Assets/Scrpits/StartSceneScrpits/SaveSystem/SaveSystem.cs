using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveByJson(string saveFileName,object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath,saveFileName);

        File.WriteAllText(path,json);
        try
        {
            Debug.Log("¥Êµµ≥…π¶" + path);
        }
        catch(System.Exception exception)
        {
            Debug.LogError("±£¥Ê¥Êµµ“Ï≥£"+path);
        }
    }
    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
        catch (System.Exception exception)
        {
            Debug.LogError("º”‘ÿ¥Êµµ“Ï≥£" + path);
            return default;
        }
    }
    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            File.Delete(path);
        }
        catch (System.Exception)
        {
            Debug.LogError("…æ≥˝¥Êµµ“Ï≥£" + path);
        }
       
    }
}
