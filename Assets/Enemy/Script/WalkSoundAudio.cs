using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSoundAudio : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    private AudioSource audioSource;
    [SerializeField] private float timeWalkSound = 0.45f;
    [SerializeField] private float timeRunSound = 0.25f;
    [HideInInspector] public bool isWalking;
    private float nextWalkSound = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void WalkingPlay()
    {
        if (Time.time > nextWalkSound)
        {
            float runOrWalkPlay = isWalking ? timeWalkSound : timeRunSound;
            nextWalkSound = Time.time + runOrWalkPlay;
            WalkingSound();
        }
    }

    private void WalkingSound()
    {
        int n = Random.Range(1, footstepSounds.Length);
        audioSource.clip = footstepSounds[n];
        audioSource.PlayOneShot(audioSource.clip);

        footstepSounds[n] = footstepSounds[0];
        footstepSounds[0] = audioSource.clip;
    }
}
