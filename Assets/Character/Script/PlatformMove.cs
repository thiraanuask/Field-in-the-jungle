using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public GameObject Player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.gameObject.transform.parent = null;
        }
    }
}
