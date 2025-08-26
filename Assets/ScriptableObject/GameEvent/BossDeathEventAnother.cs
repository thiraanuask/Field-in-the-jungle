using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossDeathEventAnother : MonoBehaviour
{
    [SerializeField] protected UnityEvent onDeathEvent;
    private HitEnemy[] hit;

    private void Start()
    {
        hit = GetComponentsInChildren<HitEnemy>();
    }

    void Update()
    {
        foreach (var hitEnemy in hit)
        {
            if (hitEnemy.isDead)
            {
                onDeathEvent.Invoke();
            }
        }
    }
}
