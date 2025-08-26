using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class WaitFail : ActionNode
{
    public float duration = 1;
    float startTime;
    public HitEnemy hitEnemy;

    protected override void OnStart() 
    {
        startTime = Time.time;
        hitEnemy = context.gameObject.GetComponentInChildren<HitEnemy>();
    }

    protected override void OnStop() 
    {
    }

    protected override State OnUpdate()
    {
        if (hitEnemy.isDead)
        {
            return State.Success;
        }
        
        if (Time.time - startTime > duration) {
            return State.Failure;
        }
        return State.Running;
    }
}
