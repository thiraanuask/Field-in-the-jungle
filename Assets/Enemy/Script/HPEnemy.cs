using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    private HitEnemy[] hit;
    public int hpEnemy = 100;
    public float destroyTime = 2f;
    void Start()
    {
        hit = GetComponentsInChildren<HitEnemy>();
    }

    void Update()
    {
        foreach (var hitEnemy in hit)
        {
            if (hitEnemy.isDead)
            {
                Destroy(this.gameObject, destroyTime);
            }
        }
    }
}
