using UnityEngine;



    public class Idle : State
    {
        public Enemy localFSM { get; set; }

        private float delayTime;
        
        public Idle(FiniteStateMachine fsm) : base(fsm)
        {
            localFSM = (Enemy)fsm;
            localFSM.isIdle = true;
        }

        public override void Enter()
        {
            localFSM.Anim.SetTrigger("IsIdle");
            delayTime = Random.Range(1, 3);
            base.Enter();
        }

        public override void Update()
        {
            delayTime -= Time.deltaTime;
            
            if (localFSM.hit.isDead)
            {
                FSM.NextState = new Dead(FSM);
                this.StateStage = StateEvent.EXIT;
            }
            
            if (delayTime <= 0 && !localFSM.hit.isDead)
            {
                //Prepare to go to the next state, Patrol
                localFSM.NextState = new Patrol(localFSM);
                this.StateStage = StateEvent.EXIT;
            }
        }
        
        public override void Exit()
        {
            localFSM.Anim.ResetTrigger("IsIdle");
            base.Enter();
        }
    }

