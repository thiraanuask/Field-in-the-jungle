using System.Collections;
using System.Collections.Generic;
using LastHopeStudio.AI;
using UnityEngine;
using TheKiwiCoder;

public class RotateFind : ActionNode
{
    public float rotationSpeed = 60;
    private float rotateTime;
    private bool clockWise;
    private AnimationAIShoot Anim;
    public HitEnemy hitEnemy;
    
    protected override void OnStart()
    {
        RandomRotationParams();
        Anim = context.gameObject.GetComponent<AnimationAIShoot>();
        hitEnemy = context.gameObject.GetComponentInChildren<HitEnemy>();
    }

    protected override void OnStop() 
    {
        
    }

    protected override State OnUpdate()
    {
        Anim.IsIdle();
        
        if (hitEnemy.isDead)
        {
            return State.Success;
        }
        
        //Check Target
        FieldOfView fov = context.gameObject.GetComponent<FieldOfView>();
        if (fov.visibleTarget && fov.visibleTarget.GetComponent<CharacterController>())
        {
            blackboard.moveToPosition = fov.visibleTarget.position;
            return State.Success;
        }

        //Agent Rotation
        float rotationDirectionMultiplier = clockWise ? 1 : -1;
        context.gameObject.transform.Rotate(new Vector3(0,1,0),rotationDirectionMultiplier * rotationSpeed * Time.deltaTime, Space.Self);

        //Timeout Rotation
        rotateTime -= Time.deltaTime;
        if (rotateTime <= 0)
        {
            return State.Failure;
        }
        
        return State.Running;
    }

    private void RandomRotationParams()
    {
        rotateTime = Random.Range(2, 4);
        float rnd = Random.Range(0, 99);
        if (rnd > 50)
            clockWise = true;
        else
            clockWise = false;
    }
    
}
