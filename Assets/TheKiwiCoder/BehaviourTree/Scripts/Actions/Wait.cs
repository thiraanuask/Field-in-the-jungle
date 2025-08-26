using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {
    public class Wait : ActionNode {
        public float duration = 1;
        float startTime;
        private AnimationAIShoot Anim;
        public HitEnemy hitEnemy;
        
        protected override void OnStart() {
            startTime = Time.time;
            Anim = context.gameObject.GetComponent<AnimationAIShoot>();
            hitEnemy = context.gameObject.GetComponentInChildren<HitEnemy>();
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            Anim.IsIdle();
            
            if (hitEnemy.isDead)
            {
                return State.Failure;
            }
            
            if (Time.time - startTime > duration) {
                return State.Success;
            }
            return State.Running;
        }
    }
}
