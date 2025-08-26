using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastHopeStudio
{
    public class AmmoBoxItem : MonoBehaviour
    {
        [SerializeField] private ItemSettings itemSettings;
        public IntegerVariable bulletAmmo;

        void Start()
        {

        }

        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                bulletAmmo.Value += itemSettings.ammo;
                Debug.Log("Pick up Ammo");
                Destroy(gameObject);
            }
        }
    }
}