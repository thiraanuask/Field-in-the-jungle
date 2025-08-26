using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckSelectorDead : ActionNode
{
    private AnimationAIShoot Anim;
    public HitEnemy hitEnemy;
    
    protected override void OnStart() 
    {
        Anim = context.gameObject.GetComponent<AnimationAIShoot>();
        hitEnemy = context.gameObject.GetComponentInChildren<HitEnemy>();
    }

    protected override void OnStop() 
    {
    }

    protected override State OnUpdate() 
    {
        if (!hitEnemy.isDead)
        {
            return State.Failure;
        }

        if (hitEnemy.isDead)
        {
            return State.Success;
        }
        
        return State.Running;
    }
}
