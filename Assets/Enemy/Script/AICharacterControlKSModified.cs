using LastHopeStudio.AI;
using UnityEngine;

namespace KS.Character
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacterKSModified))]
    public class AICharacterControlKSModified : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacterKSModified character { get; private set; } // the character we are controlling
        [HideInInspector]public FieldOfView fov;
        [HideInInspector]public Enemy enemy;
        
        //[HideInInspector]public Transform target;                                    // target to aim for


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacterKSModified>();
            fov = GetComponent<FieldOfView>();
            enemy = GetComponent<Enemy>();
            
            agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (fov.visibleTarget != null && !enemy.isIdle)
                agent.SetDestination(fov.visibleTarget.position);

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                character.Move(Vector3.zero, false, false);
                fov.visibleTarget = null;
            }
        }


        public void SetTarget(Transform target)
        {
            this.fov.visibleTarget = target;
        }
    }
}
