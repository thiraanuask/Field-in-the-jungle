using UnityEngine;




    public class Swordrun : State
    {
        public Enemy localFSM { get; set; }
        
        public Swordrun(FiniteStateMachine fsm) : base(fsm)
        {
            localFSM = (Enemy)fsm;

            localFSM.Agent.speed = localFSM.speedRun;
            localFSM.isIdle = false;
            localFSM.Walksound.isWalking = false;
        }
        
        public override void Enter()
        {
            localFSM.AIChar.SetTarget(localFSM.player);
            localFSM.Agent.SetDestination(localFSM.player.position);


            localFSM.Anim.SetTrigger("IsSwordrun");
            
            //Proceed to the next stage of the FSM's state
            base.Enter();
        }
        public override void Update()
        {
            localFSM.Walksound.WalkingPlay();
            
            #region Chasing the player

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
            //
            
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

            localFSM.Anim.ResetTrigger("IsSwordrun");

            localFSM.StopAINavigation();

            base.Exit();
        }
    }

