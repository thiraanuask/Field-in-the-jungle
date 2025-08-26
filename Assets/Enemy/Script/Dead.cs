using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class Dead : State
{
    public Enemy localFSM { get; set; }

    public Dead(FiniteStateMachine fsm) : base(fsm)
    {
        localFSM = (Enemy)fsm;
        localFSM.isIdle = true;
    }

    public override void Enter()
    {
        localFSM.Anim.SetTrigger("IsDead");
        base.Enter();
    }

    public override void Update()
    {
        localFSM.ThirdPersonChar.Move(Vector3.zero, false, false);
    }
        
    public override void Exit()
    {
    }
}
