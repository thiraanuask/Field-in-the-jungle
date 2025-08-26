using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionScript : MonoBehaviour
{
    public Transform cameraMove;
    public Camera cameraCurrent;
    
    private void Start()
    {
        cameraCurrent = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        cameraMove = cameraCurrent.transform;
    }

    private void Update()
    {
        this.gameObject.transform.rotation = cameraMove.rotation;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject,0.1f);
        }
        
        
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacles")
        {
            gameObject.tag = "Untagged";
            Destroy(GetComponent<BulletCollisionScript>());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
            Destroy(this.gameObject);
    }
}
