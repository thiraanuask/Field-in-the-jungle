using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastHopeStudio
{

    public class FirstAidItem : MonoBehaviour
    {
        [SerializeField] private ItemSettings itemSettings;
        public IntegerVariable firstAid;

        void Start()
        {

        }

        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && firstAid.Value < 100)
            {
                firstAid.Value += itemSettings.firstaid;
                if (firstAid.Value > 100)
                {
                    firstAid.Value = 100;
                }
                Debug.Log("Pick up FirstAid");
                Destroy(gameObject);
            }
        }
    }
}