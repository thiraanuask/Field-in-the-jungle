using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LastHopeStudio.GameEvent
{
    public class PickItemEvent : MonoBehaviour
    {
        [SerializeField] protected UnityEvent onPickedUp;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                onPickedUp.Invoke();
                Destroy(this.gameObject);
            }
        }
    }
}