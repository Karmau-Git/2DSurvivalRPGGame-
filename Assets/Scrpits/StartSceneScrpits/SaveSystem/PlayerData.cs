using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] string playerName = "Player Name";

    const string PLAYER_DATA_FILE_NAME = "PlayerData.Data";
    [SerializeField]class SaveData
    {
        public string playerName;
        public int playerLevel;
        public Vector3 playerPosition;
    }
    SaveData SavingData()
    {
        var saveData = new SaveData();
        saveData.playerLevel = Player.Level;
        saveData.playerPosition = transform.position;
        return saveData;
    }
    public void Save()
    {
        SaveByJson();
    }
    void LoadFromJson()
    {
        var saveData = SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
        LoadData(saveData);
    }
    void LoadData(SaveData saveData)
    {
        Player.Level = saveData.playerLevel;
        transform.position = saveData.playerPosition;
    }
    public void Load()
    {
        LoadFromJson();
    }

    void SaveByJson()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    } 
    public static void DeletePlayerDataSaveFile()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
        
    }
}
