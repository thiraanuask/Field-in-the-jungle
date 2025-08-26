using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using LastHopeStudio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GunFire : MonoBehaviour
{
    [Header("Bullet Fire Settings")]
    public GameObject Bullet;
    public float ForceMagnitude;
    public Transform offsetFire;
    public Transform cameraMove;
    public float timeToFire = 0.2f;
    private float nextFire = 0f;
    public Animator gunFireAnimtor;

    [Header("Ammo Settings")]
    public IntegerVariable bulletAmmo;
    public IntegerVariable currentAmmo;
    
    [Header("Reload Settings")]
    public float reloadTime = 1f;
    private bool isReloading = false;
    public int maxAmmo = 20;

    [Header("Effect Muzzle Flash")] 
    public ParticleSystem muzzleFlash;

    [Header("SoundEffect Gun Settings")] 
    public AudioClip gunfireSound;
    public AudioClip reloadSound;
    private AudioSource audioSource;
    
    //CheckDead
    private PlayerHit playerHit;
    
    void Start()
    {
        cameraMove = Camera.main.transform;
        audioSource = GetComponent<AudioSource>();
        playerHit = GetComponentInChildren<PlayerHit>();
    }

    void OnEnable()
    {
        isReloading = false;
        gunFireAnimtor.SetBool("IsReloading", false);
    }

    void Update()
    {
        if (!SingletonGameApplicationManager.Instance.IsPauseMenuActive)
        {
            //AudioSound
            audioSource.clip = gunfireSound;

            //Fire
            this.gameObject.transform.rotation = cameraMove.rotation;
            if (!isReloading)
            {
                if (Input.GetMouseButton(0) && Time.time >= nextFire && currentAmmo.Value > 0)
                {
                    muzzleFlash.Play();
                    audioSource.PlayOneShot(audioSource.clip);
                    nextFire = Time.time + timeToFire;
                    BulletFire();
                    currentAmmo.Value--;
                }
            }

            //Reload
            if (bulletAmmo.Value > 0 && !isReloading)
            {
                if (currentAmmo.Value <= 0 || Input.GetKeyDown(KeyCode.R) && currentAmmo.Value < maxAmmo)
                {
                    StartCoroutine(Reload());
                    return;
                }
            }

            if (bulletAmmo.Value < 0)
            {
                bulletAmmo.Value = 0;
            }

            //Fire Animation
            if (Input.GetMouseButton(0) && currentAmmo.Value > 0 && !isReloading)
            {
                gunFireAnimtor.SetBool("IsFire", true);

            }
            else
            {
                gunFireAnimtor.SetBool("IsFire", false);
            }
        }
    }
    
    
    public void BulletFire()
    {
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.position = offsetFire.position;
        
        bullet.GetComponent<Rigidbody>().AddForce(cameraMove.forward * ForceMagnitude, ForceMode.Impulse);
        Destroy(bullet,1f);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        
        gunFireAnimtor.SetBool("IsReloading", true);
        audioSource.PlayOneShot(reloadSound);
        yield return new WaitForSeconds(reloadTime - .25f);
        gunFireAnimtor.SetBool("IsReloading", false);
        yield return new WaitForSeconds(.25f);
        int bulletsToLoad = maxAmmo - currentAmmo.Value;
        int bulletsToDeduct = (bulletAmmo.Value >= bulletsToLoad) ? bulletsToLoad : bulletAmmo.Value;
        bulletAmmo.Value -= bulletsToDeduct;
        currentAmmo.Value += bulletsToDeduct;
        isReloading = false;
    }
}
