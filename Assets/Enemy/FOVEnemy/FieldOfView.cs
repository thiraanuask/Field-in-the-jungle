using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastHopeStudio.AI
{
    public class FieldOfView : MonoBehaviour
    {
        public float viewRadius;
        public float viewAngle;

        public LayerMask targets;
        public LayerMask obstacles;
        
        public Transform visibleTarget;

        private void FixedUpdate()
        {
            FindTarget();
        }

        public void FindTarget()
        {
            visibleTarget = null;
            Collider[] targetsInRadius = Physics.OverlapSphere(transform.position, viewRadius, targets);
            foreach (Collider selectedTarget in targetsInRadius)
            {
                Transform target = selectedTarget.transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (!Physics.Raycast(transform.position, dirToTarget, distanceToTarget,obstacles))
                        visibleTarget = target;
                }
            }
        }

        public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }
            
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0f,Mathf.Cos(angleInDegrees*Mathf.Deg2Rad));
        }
    }
}