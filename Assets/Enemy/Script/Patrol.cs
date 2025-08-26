using UnityEngine;


    public class Patrol : State
    {
        public Enemy localFSM { get; set; }
        
        private int currentWaypointIdx = -1;
        
        public Patrol(FiniteStateMachine fsm) : base(fsm)
        {
            localFSM = (Enemy)fsm;

            localFSM.Agent.speed = localFSM.speedWalk;
            localFSM.isIdle = false;
            localFSM.Walksound.isWalking = true;
        }

        public override void Enter()
        {
            float lastDist = Mathf.Infinity; // Store distance between NPC and waypoints.
            
            // Calculate closest waypoint by looping around each one and calculating the distance between the NPC and each waypoint.
            for (int i = 0; i < localFSM.wayPoints.Count; i++)
            {
                GameObject thisWP = localFSM.wayPoints[i].gameObject;
                float distance = Vector3.Distance(localFSM.NpcGameObject.transform.position, thisWP.transform.position);
                if(distance < lastDist)
                {
                    currentWaypointIdx = i;
                    lastDist = distance;

                    localFSM.AIChar.SetTarget(thisWP.transform);
                }            
            }
            
            localFSM.Anim.SetTrigger("IsWalk");
            
            //Proceed to the next stage of the FSM
            base.Enter();
        }
        
        public override void Update()
        {
            localFSM.Walksound.WalkingPlay();
            
            if (localFSM.AIChar.fov.visibleTarget != null)
                localFSM.Agent.SetDestination(localFSM.AIChar.fov.visibleTarget.position);

            if (localFSM.Agent.remainingDistance > localFSM.Agent.stoppingDistance)
            {
                //Move the agent
                //localFSM.ThirdPersonChar.Move(localFSM.Agent.desiredVelocity, false, false);
            }
            else
            {
                //increase waypoint index
                if (currentWaypointIdx >= localFSM.wayPoints.Count-1)
                    currentWaypointIdx = 0;
                else
                    currentWaypointIdx++;

                //Set target to the next waypoint
                localFSM.AIChar.SetTarget(localFSM.wayPoints[currentWaypointIdx]);
                //localFSM.Agent.SetDestination(localFSM.AIChar.target.position);

                //Stop the character movement
                localFSM.ThirdPersonChar.Move(Vector3.zero, false, false);
            }

            //Check State
            
            if (localFSM.hit.isDead)
            {
                FSM.NextState = new Dead(FSM);
                this.StateStage = StateEvent.EXIT;
            }
            
            if (localFSM.CanSeePlayer() && !localFSM.hit.isDead)
            {
                FSM.NextState = new Swordrun(FSM);
                this.StateStage = StateEvent.EXIT;
            }

        }
        
        public override void Exit()
        {
            localFSM.Anim.ResetTrigger("IsWalk");
            localFSM.StopAINavigation();
            base.Exit();
        }
    }

