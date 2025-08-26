using System.Collections;
using System.Collections.Generic;
using LastHopeStudio.AI;
using UnityEngine;
using TheKiwiCoder;

public class ShootPlayer : ActionNode
{
    public GameObject Bullet;
    public float rotationSpeed = 60;
    public bool updateRotation = true;
    public float ForceMagnitude;
    public float destroyTime = 1f;
    private ShootSound shootSound;
    private TriggerShoot trigPlayer;
    private AnimationAIShoot Anim;
    public HitEnemy hitEnemy;
    
    protected override void OnStart()
    {
        trigPlayer = context.gameObject.GetComponentInChildren<TriggerShoot>();
        Anim = context.gameObject.GetComponent<AnimationAIShoot>();
        shootSound = context.gameObject.GetComponent<ShootSound>();
        hitEnemy = context.gameObject.GetComponentInChildren<HitEnemy>();
    }

    protected override void OnStop() 
    {
    }

    protected override State OnUpdate() 
    {
        FieldOfView fov = context.gameObject.GetComponent<FieldOfView>();

        if (hitEnemy.isDead)
        {
            return State.Failure;
        }
        
        context.agent.updateRotation = updateRotation;
        context.transform.LookAt(trigPlayer.target);
        if(trigPlayer)
        {
            Anim.IsShooting();
            shootSound.ShootSoundPlay();
            OnShoot();
            return State.Success;
        }
        
        if (!trigPlayer)
        {
            return State.Failure;
        }

        return State.Running;
    }

    void OnShoot()
    {
        GameObject bullet = Instantiate(Bullet,trigPlayer.offsetShoot.position,context.gameObject.transform.rotation);
        Vector3 bulletVector = trigPlayer.offsetShoot.transform.forward;
        bulletVector.y = 0;
        bullet.GetComponent<Rigidbody>().AddForce(bulletVector * ForceMagnitude, ForceMode.Impulse);
        Destroy(bullet, destroyTime);
    }
}
