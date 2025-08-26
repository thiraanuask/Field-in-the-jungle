using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackTrigger : MonoBehaviour
{
   public UnityEvent callWhenTriggerEnter;
   public UnityEvent callWhenTriggerExit;

   [SerializeField] private Collider playerCollider;
   
   private void Start()
   {
      playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider>();
   }

   private void OnTriggerEnter(Collider other)
   {
      if(other == playerCollider)
         callWhenTriggerEnter.Invoke();
   }

   private void OnTriggerExit(Collider other)
   {
      if(other == playerCollider)
         callWhenTriggerExit.Invoke();
   }
}
