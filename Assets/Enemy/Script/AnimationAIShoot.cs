using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAIShoot : MonoBehaviour
{
    [HideInInspector]public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void IsWalking()
    {
        animator.SetTrigger("isWalk");
    }

    public void IsShooting()
    {
        animator.SetTrigger("isShoot");
    }

    public void IsDead()
    {
        animator.SetTrigger("isDead");
    }

    public void IsIdle()
    {
        animator.SetTrigger("isIdle");
    }
    
}
