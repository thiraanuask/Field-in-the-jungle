using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.TestTools;

public class SingletonSoundManager : Singleton<SingletonSoundManager>
{
    public const float MUTE_VOLUME = -80;

    [SerializeField] 
    protected AudioMixer mixer;
    public AudioMixer Mixer
    {
        get { return mixer;} set { mixer = value; }
    }
    public AudioSource BGMSource { get; set; }

    #region Master Volume

    public float MasterVolumeDefault { get; set; }

    protected float masterVolume;
    
    public float MasterVolume
    {
        get
        {
            return this.masterVolume;
        }
        set
        {
            this.masterVolume = value;
            Instance.Mixer.SetFloat("MasterVolume", this.masterVolume);
        }
    }
    
    #endregion

    #region MusicVolume

    public float MusicVolumeDefault { get; set; }

    protected float musicVolume;

    public float MusicVolume
    {
        get
        {
            return this.musicVolume;
        }
        set
        {
            this.musicVolume = value;
            Instance.Mixer.SetFloat("MusicVolume", this.musicVolume);
        }
    } 

    #endregion

    #region MasterSFXVolume

    public float MasterSFXVolumeDefault { get; set; }

    protected float sfxVolume;

    public float MasterSFXVolume
    {
        get
        {
            return this.sfxVolume;
        }
        set 
        {
            this.sfxVolume = value;
            Instance.Mixer.SetFloat("MasterSFXVolume", this.sfxVolume);
        }
    }

    #endregion
    
    public override void Awake()
    {
        base.Awake();

        this.BGMSource = this.GetComponent<AudioSource>();

        float masterVolume;
        if (mixer.GetFloat("MasterVolume", out masterVolume))
            Instance.MasterVolumeDefault = masterVolume;
        float musicVolume;
        if (mixer.GetFloat("MusicVolume", out musicVolume))
            Instance.MusicVolumeDefault = musicVolume;
        float sfxVolume;
        if (mixer.GetFloat("MasterSFXVolume", out sfxVolume))
            Instance.MasterSFXVolumeDefault = sfxVolume;


    }
}
