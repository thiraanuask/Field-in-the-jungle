using UnityEngine;


    public class Taunt : State
    {
        public Enemy localFSM { get; set; }
        
        private float delayTime;
        
        public Taunt(FiniteStateMachine fsm) : base(fsm)
        {
            localFSM = (Enemy)fsm;
        }

        public override void Enter()
        {
            localFSM.Anim.SetTrigger("IsTaunt");
            delayTime = Random.Range(2, 5);
            base.Enter();
        }

        public override void Update()
        {
            delayTime -= Time.deltaTime;
            
            //Check Dead
            if (localFSM.hit.isDead)
            {
                FSM.NextState = new Dead(FSM);
                this.StateStage = StateEvent.EXIT;
            }
            //
            
            if (delayTime <= 0 && !localFSM.hit.isDead)
            {
                //Prepare to go to the next state, Patrol
                localFSM.NextState = new Idle(localFSM);
                this.StateStage = StateEvent.EXIT;
            }
        }

        public override void Exit()
        {
            
            localFSM.Anim.ResetTrigger("IsTaunt");
            base.Exit();
        }
        
    }

