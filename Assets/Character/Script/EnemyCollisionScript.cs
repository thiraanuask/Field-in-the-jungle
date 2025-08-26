using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionScript : MonoBehaviour
{
    private float timeDestroy;
    private bool isDead;
    void Start()
    {
        
    }

    void Update()
    {
        if(isDead)
        {
            timeDestroy += Time.deltaTime;
        }
        else
        {
            timeDestroy = 0;
        }
        if (timeDestroy > 2)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            isDead = true;
        }
    }
}
