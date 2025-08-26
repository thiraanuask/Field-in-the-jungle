using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Searching : State
{
    public Enemy localFSM { get; set; }

    private float delayTime;
    private float ranRotate;
    private float ranAnimate;
    public Searching(FiniteStateMachine fsm) : base(fsm)
    {
        localFSM = (Enemy) fsm;
        localFSM.isIdle = false;
    }

    public override void Enter()
    {
        localFSM.Anim.SetTrigger("IsSearching");
        delayTime = Random.Range(3, 8);
        ranRotate = Random.Range(1, 8);
        ranAnimate = Random.Range(1, 6);
        base.Enter();
    }

    public override void Update()
    {
        delayTime -= Time.deltaTime;

        if(ranRotate > 5)
            localFSM.Agent.transform.Rotate(0,-100 * Time.deltaTime,0);
        else
            localFSM.Agent.transform.Rotate(0,100 * Time.deltaTime,0);

        //Check Dead
        if (localFSM.hit.isDead)
        {
            FSM.NextState = new Dead(FSM);
            this.StateStage = StateEvent.EXIT;
        }
        //
        
        if (localFSM.CanSeePlayer() && !localFSM.hit.isDead)
        {
            FSM.NextState = new Swordrun(FSM);
            this.StateStage = StateEvent.EXIT;
        }

        if (!localFSM.CanSeePlayer() && !localFSM.hit.isDead)
        {
            if (ranAnimate > 4)
            {
                if (delayTime <= 0)
                {
                    FSM.NextState = new Idle(FSM);
                    this.StateStage = StateEvent.EXIT;
                }
            }
            else if(delayTime <= 0)
            {
                FSM.NextState = new Taunt(FSM);
                this.StateStage = StateEvent.EXIT;
            }
        }
    }

    public override void Exit()
    {
        localFSM.Anim.ResetTrigger("IsSearching");
        localFSM.StopAINavigation();
        
        base.Exit();
    }

}
