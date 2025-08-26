using System.Collections;
using System.Collections.Generic;
using System.IO;
using LastHopeStudio;
using UnityEngine;

public class LoadGamePreferencesData : MonoBehaviour
{
    private string _saveFolderLocation;
    public FloatVariable mouseSpeed;

    void Start()
    {
        _saveFolderLocation = "Saves";
        
        string filename = "SaveOptionData";
        string location = Path.Combine(_saveFolderLocation, filename);

        ISaveLoadGamePreferencesData islg = null;
        islg = new SaveLoadGamePreferencesDataJSON();
        location = location + ".json";

        GamePreferencesData gpd = new GamePreferencesData();
        gpd = islg.LoadGamePreferencesData(location);
        SingletonGameApplicationManager.Instance.MasterValue = gpd._masterVolume;
        SingletonGameApplicationManager.Instance.MusicValue = gpd._musicVolume;
        SingletonGameApplicationManager.Instance.SFXValue = gpd._SFXVolume;
        mouseSpeed.Value = gpd._mouseSentivity;
        SingletonGameApplicationManager.Instance.MasterEnable = gpd._isMaster;
        SingletonGameApplicationManager.Instance.MusicEnable = gpd._isMusic;
        SingletonGameApplicationManager.Instance.SFXEnable = gpd._isSFX;
        
        if(SingletonGameApplicationManager.Instance.MasterEnable)
            SingletonSoundManager.Instance.Mixer.SetFloat("MasterVolume", Mathf.Log10(SingletonGameApplicationManager.Instance.MasterValue) * 20);
        else
            SingletonSoundManager.Instance.Mixer.SetFloat("MasterVolume", Mathf.Log10(SingletonSoundManager.MUTE_VOLUME) * 20);
        if(SingletonGameApplicationManager.Instance.MusicEnable)
            SingletonSoundManager.Instance.Mixer.SetFloat("MusicVolume", Mathf.Log10(SingletonGameApplicationManager.Instance.MusicValue) * 20);
        else
            SingletonSoundManager.Instance.Mixer.SetFloat("MusicVolume", Mathf.Log10(SingletonSoundManager.MUTE_VOLUME) * 20);
        if(SingletonGameApplicationManager.Instance.SFXEnable)
            SingletonSoundManager.Instance.Mixer.SetFloat("MasterSFXVolume", Mathf.Log10(SingletonGameApplicationManager.Instance.SFXValue)*20);
        else
            SingletonSoundManager.Instance.Mixer.SetFloat("MasterSFXVolume", Mathf.Log10(SingletonSoundManager.MUTE_VOLUME) * 20);
    }
}
