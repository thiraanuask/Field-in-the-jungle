using System.Collections;
using System.Collections.Generic;
using LastHopeStudio.AI;
using UnityEngine;
using TheKiwiCoder;

public class ChasePlayer : ActionNode
{
    public float speed = 5;
    public float stoppingDistance = 0.1f;
    public bool updateRotation = true;
    public float acceleration = 40.0f;
    private AnimationAIShoot Anim;
    private WalkSoundAudio walkSound;
    public HitEnemy hitEnemy;
    
    protected override void OnStart() 
    {
        context.agent.speed = speed;
        context.agent.acceleration = acceleration;
        Anim = context.gameObject.GetComponent<AnimationAIShoot>();
        walkSound = context.gameObject.GetComponent<WalkSoundAudio>();
        hitEnemy = context.gameObject.GetComponentInChildren<HitEnemy>();
    }

    protected override void OnStop() 
    {
        
    }

    protected override State OnUpdate() 
    {
        Anim.IsWalking();
        walkSound.WalkingPlay();
        FieldOfView fov = context.gameObject.GetComponent<FieldOfView>();
        TriggerShoot trigPlayer = context.gameObject.GetComponentInChildren<TriggerShoot>();
        context.transform.LookAt(trigPlayer.target);
        context.agent.updateRotation = updateRotation;

        if (hitEnemy.isDead)
        {
            return State.Failure;
        }
        
        if (fov.visibleTarget && fov.visibleTarget.GetComponent<CharacterController>())
        {
            context.agent.stoppingDistance = stoppingDistance;
            blackboard.moveToPosition = fov.visibleTarget.position;
            context.agent.destination = blackboard.moveToPosition;
            if (trigPlayer.isShoot)
            {
                return State.Success;
            }
        }
        else
        {
            return State.Failure;
        }
        return State.Running;
    }
}
