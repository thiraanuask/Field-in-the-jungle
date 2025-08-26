using UnityEngine;


    public class Run : State
    {
        public Enemy localFSM { get; set; }
        
        public Run(FiniteStateMachine fsm) : base(fsm)
        {
            localFSM = (Enemy)fsm;
            localFSM.isIdle = false;
            localFSM.Walksound.isWalking = false;
        }

        public override void Enter()
        {
            localFSM.AIChar.SetTarget(localFSM.player);
            localFSM.Agent.SetDestination(localFSM.player.position);
            
            localFSM.Anim.SetTrigger("IsRun");

            base.Enter();
        }

        public override void Update()
        {
            #region Chasing the player

            localFSM.Walksound.WalkingPlay();
            
            localFSM.Agent.SetDestination(localFSM.player.position);
            
            if (localFSM.Agent.remainingDistance > localFSM.Agent.stoppingDistance)
            {
                //Move the agent
                //localFSM.ThirdPersonChar.Move(localFSM.Agent.desiredVelocity, false, false);
            }

            #endregion
            
            //Check Dead
            if (localFSM.hit.isDead)
            {
                FSM.NextState = new Dead(FSM);
                this.StateStage = StateEvent.EXIT;
            }
            
            #region Checking if the player is escaped successfully/behind

            if (!localFSM.CanSeePlayer() && !localFSM.hit.isDead)
            {
                FSM.NextState = new Searching(FSM);
                this.StateStage = StateEvent.EXIT;
            }

            #endregion
            
            
            if (localFSM.IsPlayerInAttackRange && !localFSM.hit.isDead)
            {
                FSM.NextState = new Attack(FSM);
                this.StateStage = StateEvent.EXIT;
            }
        }

        public override void Exit()
        {
            localFSM.Anim.ResetTrigger("IsRun");

            localFSM.StopAINavigation();
            
            base.Exit();
        }
    }

