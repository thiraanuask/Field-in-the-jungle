using System.Collections;
using System.Collections.Generic;
using LastHopeStudio.AI;
using UnityEngine;
using TheKiwiCoder;

public class MoveToFind : ActionNode
{
    public float speed = 5;
    public float stoppingDistance = 0.1f;
    public bool updateRotation = true;
    public float acceleration = 40.0f;
    public float tolerance = 1.0f;
    private AnimationAIShoot Anim;
    private WalkSoundAudio walkSound;
    public HitEnemy hitEnemy;
    
    protected override void OnStart() 
    {
        Anim = context.gameObject.GetComponent<AnimationAIShoot>();
        walkSound = context.gameObject.GetComponent<WalkSoundAudio>();
        hitEnemy = context.gameObject.GetComponentInChildren<HitEnemy>();
        context.agent.stoppingDistance = stoppingDistance;
        context.agent.speed = speed;
        context.agent.destination = blackboard.moveToPosition;
        context.agent.updateRotation = updateRotation;
        context.agent.acceleration = acceleration;
    }

    protected override void OnStop() 
    {
    }

    protected override State OnUpdate() 
    {
        Anim.IsWalking();
        walkSound.WalkingPlay();
        
        //Check Target
        FieldOfView fov = context.gameObject.GetComponent<FieldOfView>();
        
        if (hitEnemy.isDead)
        {
            return State.Success;
        }
        
        if (fov.visibleTarget && fov.visibleTarget.GetComponent<CharacterController>())
        {
            return State.Success;
        }
        
        if (context.agent.pathPending) {
            return State.Running;
        }

        if (context.agent.remainingDistance < tolerance) {
            return State.Failure;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }
        
        
        return State.Running;
    }
}
