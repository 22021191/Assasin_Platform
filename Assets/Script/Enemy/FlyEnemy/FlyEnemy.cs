using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class FlyEnemy : Enemy
{
    public FlyAttackState attack { get; private set; }
    public FlyIdleState idle { get; private set; }
    public FlySleepState sleep { get; private set; }
    public FlyMove move { get; private set; }

    [Header("Value Other")]
    public Transform startPos;
    public Vector3 direction;
    public override void Awake()
    {
        base.Awake();
        

        attack = new FlyAttackState(this, stateMachine, "Attack", data, playerCheck);
        idle = new FlyIdleState(this, stateMachine, "Idle",data);
        sleep = new FlySleepState(this, stateMachine, "Idle", data);
        move = new FlyMove(this, stateMachine, "Idle", data);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Start()
    {
        base.Start();
        stateMachine.Initialize(sleep);
    }

    public override void Update()
    {
        base.Update();
    }
    public void SetVelocity(Vector3 direction)
    {
        rb2d.velocity = direction * data.force;
    }
    public Transform LookPlayer()
    {
        Collider2D detectedObjects = Physics2D.OverlapCircle(startPos.position, data.maxLookPlayerDistance, data._PlayerMask);
        if (detectedObjects == null)
        {
            return null;
        }
        return detectedObjects.transform;
    }
    public void RotationPlayer(Transform player)
    {
        direction = player.position - transform.position;
        direction=direction.normalized;
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;   
        Gizmos.DrawWireSphere(playerCheck.transform.position, data.attackDistance);
        Gizmos.DrawWireSphere(transform.position, data.maxLookPlayerDistance);
    
    }

}
