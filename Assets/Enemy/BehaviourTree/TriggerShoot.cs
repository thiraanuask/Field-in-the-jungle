using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShoot : MonoBehaviour
{
    public bool isShoot;
    public Transform offsetShoot;
    public Transform target;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isShoot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isShoot = false;
        }
    }
}
