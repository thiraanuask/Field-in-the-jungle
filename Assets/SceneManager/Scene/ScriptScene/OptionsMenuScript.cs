using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using LastHopeStudio;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public Toggle masterToggle;
    public Toggle musicToggle;
    public Toggle sfxToggle;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Button backButton;
    
    //ScriptableObject
    [Header("ScriptableObject Settings")]
    public FloatVariable mouseSpeed;
    [SerializeField] Slider mouseSlider;
    [SerializeField] private TextMeshProUGUI mouseSpeedText;
    void Start()
    {
        masterToggle.isOn = SingletonGameApplicationManager.Instance.MasterEnable;
        musicToggle.isOn = SingletonGameApplicationManager.Instance.MusicEnable;
        sfxToggle.isOn = SingletonGameApplicationManager.Instance.SFXEnable;
        
        masterToggle.onValueChanged.AddListener(delegate {OnMasterToggleClick(masterToggle);  });
        musicToggle.onValueChanged.AddListener(delegate {OnMusicToggleClick(musicToggle);  });
        sfxToggle.onValueChanged.AddListener(delegate {OnSFXToggleClick(sfxToggle);  });
        backButton.onClick.AddListener(delegate { BackButtonClick(backButton); });
        
    }
    
    void Update()
    {
        masterSlider.value =  SingletonGameApplicationManager.Instance.MasterValue;
        SingletonSoundManager.Instance.MasterVolumeDefault = masterSlider.value;

        musicSlider.value = SingletonGameApplicationManager.Instance.MusicValue;
        SingletonSoundManager.Instance.MusicVolumeDefault = musicSlider.value;

        sfxSlider.value = SingletonGameApplicationManager.Instance.SFXValue;
        SingletonSoundManager.Instance.MasterSFXVolumeDefault = sfxSlider.value;
        
        //ScriptableObjects
        mouseSlider.value = mouseSpeed.Value;
        mouseSpeedText.text = (Math.Round(mouseSpeed.Value,1)).ToString();
    }

    public void BackButtonClick(Button button)
    {
        SceneManager.UnloadSceneAsync("SceneOptions");
        SingletonGameApplicationManager.Instance.IsOptionsMenuActive = false;
    }

    public void OnMasterToggleClick(Toggle toggle)
    {
        SingletonGameApplicationManager.Instance.MasterEnable = masterToggle.isOn;
        if (SingletonGameApplicationManager.Instance.MasterEnable)
            SingletonSoundManager.Instance.MasterVolume = SingletonSoundManager.Instance.MasterVolumeDefault;
        else
            SingletonSoundManager.Instance.MasterVolume = SingletonSoundManager.MUTE_VOLUME;
    }

    public void OnMusicToggleClick(Toggle toggle)
    {
        SingletonGameApplicationManager.Instance.MusicEnable = musicToggle.isOn;
        if (SingletonGameApplicationManager.Instance.MusicEnable)
            SingletonSoundManager.Instance.MusicVolume = SingletonSoundManager.Instance.MusicVolumeDefault;
        else
            SingletonSoundManager.Instance.MusicVolume = SingletonSoundManager.MUTE_VOLUME;
    }

    public void OnSFXToggleClick(Toggle toggle)
    {
        SingletonGameApplicationManager.Instance.SFXEnable = sfxToggle.isOn;
        if (SingletonGameApplicationManager.Instance.SFXEnable = sfxToggle.isOn)
            SingletonSoundManager.Instance.MasterSFXVolume = SingletonSoundManager.Instance.MasterSFXVolumeDefault;
        else
            SingletonSoundManager.Instance.MasterSFXVolume = SingletonSoundManager.MUTE_VOLUME;
    }

    public void OnMasterSliderChange(float val)
    {
        SingletonGameApplicationManager.Instance.MasterValue = val;
        if (masterToggle.isOn)
        {
            SingletonSoundManager.Instance.Mixer.SetFloat("MasterVolume", Mathf.Log10(val) * 20);
        }
    }

    public void OnMusicSliderChange(float val)
    {
        SingletonGameApplicationManager.Instance.MusicValue = val;
        if (musicToggle.isOn)
        {
            SingletonSoundManager.Instance.Mixer.SetFloat("MusicVolume", Mathf.Log10(val) * 20);
        }
    }

    public void OnSFXSliderChange(float val)
    {
        SingletonGameApplicationManager.Instance.SFXValue = val;
        if (sfxToggle.isOn)
        {
            SingletonSoundManager.Instance.Mixer.SetFloat("MasterSFXVolume", Mathf.Log10(val) * 20);
        }
        
    }

    public void OnMouseSpeedChange(float val)
    {
        mouseSpeed.Value = val;
    }
}
