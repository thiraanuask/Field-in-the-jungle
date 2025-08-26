using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    private HPEnemy hp;
    public int hitEnemy = 30;
    private float timeToHit = 0.1f;
    private float nextHit = 0f;
    private float timeToDead = 3f;
    private float nextDead = 0f;
    [HideInInspector]public bool isDead = false;
    public AudioSource audioSource;
    public AudioSource audioSourceLocal;
    public AudioClip hitSound;
    public AudioClip deadSound;
    
    void Start()
    {
        hp = GetComponentInParent<HPEnemy>();
        audioSource = GetComponentInParent<AudioSource>();
        audioSourceLocal = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        EnemyDead();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (hp.hpEnemy > 0 && Time.time >= nextHit)
            {
                Debug.Log("Hit!");
                audioSourceLocal.PlayOneShot(hitSound);
                nextHit = Time.time + timeToHit;
                hp.hpEnemy -= hitEnemy;
            }
        }
    }

    private void EnemyDead()
    {
        if (hp.hpEnemy <= 0 && Time.time >= nextDead)
        {
            audioSource.PlayOneShot(deadSound);
            nextDead = Time.time + timeToDead;
            isDead = true;
            hp.hpEnemy = 0;
        }
    }
}
