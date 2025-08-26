using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip shootAudio;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ShootSoundPlay()
    {
        audioSource.PlayOneShot(shootAudio);
    }
    
}
