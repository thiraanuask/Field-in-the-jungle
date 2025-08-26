using UnityEngine;



    public class Attack : State
    {
        public Enemy localFSM { get; set; }

        public Attack(FiniteStateMachine fsm) : base(fsm)
        {
            localFSM = (Enemy)fsm;
        }

        public override void Enter()
        {
            
            localFSM.Anim.SetTrigger("IsAttack");
            localFSM.StopAINavigation();

            base.Enter();
        }
        
        
        
        public override void Update()
        {
            if (localFSM.hit.isDead)
            {
                FSM.NextState = new Dead(FSM);
                this.StateStage = StateEvent.EXIT;
            }
            
            if (!localFSM.IsPlayerInAttackRange)
            {
                if (!localFSM.CanSeePlayer())
                {
                    FSM.NextState = new Searching(FSM);
                    this.StateStage = StateEvent.EXIT;
                    
                }
                else
                {
                    FSM.NextState = new Run(FSM);
                    this.StateStage = StateEvent.EXIT;
                }
            }
        }
        
        public override void Exit()
        {
            localFSM.Anim.ResetTrigger("IsAttack");

            localFSM.StopAINavigation();

            base.Exit();
        }
    }

