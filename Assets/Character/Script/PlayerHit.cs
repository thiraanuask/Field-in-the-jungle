using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;
using IntegerVariable = LastHopeStudio.IntegerVariable;

public class PlayerHit : MonoBehaviour
{
    public GameObject isDeadRemoveGun;
    public IntegerVariable hp;
    [HideInInspector]public bool isDead;
    public Animator animator;
    
    [Header("Settings Delay Hit")]
    public float timeToHit = 0.2f;
    private float nextHit = 0f;
    private float timeToDeathS = 10f;
    private float nextDeathS = 0f;
    
    [Header("Settings GameOver")]
    private int gameOverScene = 7;
    private float gameOverTime;
    public float delayGameOver;
    
    //Audio
    [Header("Settings Damage Sound")]
    private AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip deathSound;
    [Header("Settings Get Item Sound")]
    public AudioClip ammoBoxSound;
    public AudioClip firstAidSound;
    public AudioClip keySound;

    //GodMode
    private GodModeScript godMod;

    private void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
        godMod = GetComponentInParent<GodModeScript>();
    }

    private void Update()
    {
        gameOverTime -= Time.deltaTime;
        CheckDead();
        LowHPAnimation();
    }

    public void LowHPAnimation()
    {
        if (hp.Value > 50)
        {
            animator.SetBool("IsLow50",false);
            animator.SetBool("IsLow25", false);
        }
        else if (hp.Value > 25)
        {
            animator.SetBool("IsLow50",true);
            animator.SetBool("IsLow25",false);
        }
        else if (hp.Value > 0)
        {
            animator.SetBool("IsLow50",true);
            animator.SetBool("IsLow25",true);
        }
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        //Check Hit Damage
        if (collider.CompareTag("Blade") && !godMod.isGodMode)
        {
            if (!isDead && Time.time >= nextHit)
            {
                audioSource.PlayOneShot(hitSound);
                nextHit = Time.time + timeToHit;
                hp.Value -= 30;
            }
        }

        //Sound AmmoBox
        if (collider.CompareTag("AmmoBox"))
        {
            audioSource.PlayOneShot(ammoBoxSound);
            Debug.Log("AmmoSound");
        }

        //Sound FirstAid
        if (collider.CompareTag("FirstAid")&& hp.Value < 100)
        {
            Debug.Log("FirstAidSound");
            audioSource.PlayOneShot(firstAidSound);
        }

        //Sound Key
        if (collider.CompareTag("Key"))
        {
            Debug.Log("Key");
            audioSource.PlayOneShot(keySound);
        }
    }

    //Fall Lava and Sea
    public void FallDeath()
    {
        hp.Value -= 100;
    }
    
    public void CheckDead()
    {
        if (hp.Value <= 0)
        {
            isDeadRemoveGun.SetActive(false);
            isDead = true;
            hp.Value = 0;
            
            if(gameOverTime < 0)
                GameOverLoad();
        }

        if (isDead)
        {
            if (Time.time >= nextDeathS)
            {
                nextDeathS = Time.time + timeToDeathS;
                audioSource.PlayOneShot(deathSound);
            }
        }
        
        if (!isDead)
        {
            gameOverTime = delayGameOver;
        }
    }
    
    public void GameOverLoad()
    {
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(LoadAsynchronously());
    }
    
    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(gameOverScene);
        

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/.9f);
            yield return null;
        }
    }
}
