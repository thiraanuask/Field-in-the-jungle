using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class EnemyDead : ActionNode
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
            return State.Success;   
        }

        if (hitEnemy.isDead)
        {
            Anim.IsDead();
            return State.Failure;
        }
        
        return State.Running;
    }
}
