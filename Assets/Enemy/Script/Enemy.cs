using System;
using System.Collections.Generic;
using KS.Character;
using LastHopeStudio.AI;
using UnityEngine;
using UnityEngine.AI;

    
    [RequireComponent(typeof(ThirdPersonCharacterKSModified))]
    [RequireComponent(typeof(AICharacterControlKSModified))]
    public class Enemy : FiniteStateMachine
    {
        #region ForestPeople Character Vars

        [HideInInspector]public GameObject NpcGameObject;
        public Animator Anim { get; set; }
        public ThirdPersonCharacterKSModified ThirdPersonChar { get; set; }
        public AICharacterControlKSModified AIChar{ get; set; }
        public NavMeshAgent Agent{ get; set; }

        [HideInInspector]public FieldOfView fov;

        [HideInInspector]public bool isIdle;

        [HideInInspector]public HitEnemy hit;
        
        public float speedWalk = 2;
        public float speedRun = 5;

        [HideInInspector] public WalkSoundAudio Walksound;
        
        #endregion
        
        //The player to be tracked
        [HideInInspector]public Transform player;
        public Transform Player
        {
            get { return player; }
        }

        
        [SerializeField] public List<Transform> wayPoints;
        
        
        private void Start()
        {
            NpcGameObject = GetComponent<Transform>().gameObject;
            
            Anim = GetComponent<Animator>();
            ThirdPersonChar = GetComponent<ThirdPersonCharacterKSModified>();
            AIChar = GetComponent<AICharacterControlKSModified>();
            Agent =  GetComponent<NavMeshAgent>();
            fov = GetComponent<FieldOfView>();
            Walksound = GetComponent<WalkSoundAudio>();
            
            //Check Dead
            hit = GetComponentInChildren<HitEnemy>();
            
            //Automatically find player
            //this.player = GameObject.FindWithTag("Player").transform;

            CurrentState = new Idle(this);
        }

        public void StopAINavigation() {
            //Stop Moving
            ThirdPersonChar.Move(Vector3.zero, false, false);
            AIChar.SetTarget(null);
            Agent.SetDestination(NpcGameObject.transform.position);
        }

        #region Check Player Range

        public bool CanSeePlayer()
        {
            /*Vector3 direction = player.position - NpcGameObject.transform.position; // Provides the vector from the NPC to the player.
            float angle = Vector3.Angle(direction, NpcGameObject.transform.forward);*/ // Provide angle of sight.

            // If player is close enough to the NPC AND within the visible viewing angle...
            if(fov.visibleTarget != null && fov.visibleTarget.GetComponent<CharacterController>() && !isIdle)
            {
               player = fov.visibleTarget;
               return true; // NPC CAN see the player.
            }
            return false; // NPC CANNOT see the player.
        }
        
        /*public bool IsPlayerBehind()
        {
            Vector3 direction = NpcGameObject.transform.position - player.position; // Provides the vector from the player to the NPC.
            float angle = Vector3.Angle(direction, NpcGameObject.transform.forward); // Provide angle of sight.

            // If player is close enough to the NPC AND within the visible viewing angle...
            if (direction.magnitude > fov.viewRadius && angle > fov.viewAngle)
            {
                return true; // Player IS behind the NPC.
            }
            return false; // Player IS NOT behind the NPC.
        }*/

        #endregion
        
        #region Bounding Box Attack Range

        public bool IsPlayerInAttackRange { get; set; }

        public void SetPlayerInAttackRange()
        {
            IsPlayerInAttackRange = true;
        }
        public void ResetPlayerInAttackRange()
        {
            IsPlayerInAttackRange = false;
        }

        #endregion
        
    }

