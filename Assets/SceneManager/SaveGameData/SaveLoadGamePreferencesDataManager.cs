using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LastHopeStudio;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadGamePreferencesDataManager : MonoBehaviour
{
    [SerializeField] 
    private Button _saveButton;
    public FloatVariable mouseSpeed;
    private string _saveFolderLocation;
    void Start()
    {
        _saveButton.onClick.AddListener(OnSaveClick);

        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");
        _saveFolderLocation = "Saves";
    }
    
    void Update()
    {
        
    }

    void OnSaveClick()
    {
        GamePreferencesData gpd = new GamePreferencesData
        {
            _masterVolume = SingletonGameApplicationManager.Instance.MasterValue,
            _musicVolume = SingletonGameApplicationManager.Instance.MusicValue,
            _SFXVolume = SingletonGameApplicationManager.Instance.SFXValue,
            _mouseSentivity = mouseSpeed.Value,
            _isMaster = SingletonGameApplicationManager.Instance.MasterEnable,
            _isMusic = SingletonGameApplicationManager.Instance.MusicEnable,
            _isSFX = SingletonGameApplicationManager.Instance.SFXEnable,
        };

        string filename = "SaveOptionData";
        string location = Path.Combine(_saveFolderLocation, filename);

        ISaveLoadGamePreferencesData islg = null;
        
        islg = new SaveLoadGamePreferencesDataJSON();
        location = location + ".json";
        islg.SaveGamePreferencesData(gpd, location); 
    }
}
