using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    public FlyAttackState attack { get; private set; }
    public FlyChaseState chase { get; private set; }
    public FlyIdleState idle { get; private set; }
    public FlyMoveState move { get; private set; }
    
    [Header("Value Other")]
    public Transform startPos;
    private Transform attackPos;
    public override void Awake()
    {
        base.Awake();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Start()
    {
        base.Start();

        attack = new FlyAttackState(this, stateMachine, "Attack", data, attackPos);
        idle = new FlyIdleState(this, stateMachine, "Idle",data);
        move = new FlyMoveState(this, stateMachine, "Move", data);
        chase = new FlyChaseState(this, stateMachine, "Chase", data);
    }

    public override void Update()
    {
        base.Update();
    }

    public bool LookPlayer()
    {
        return Physics2D.OverlapCircle(startPos.position, data.maxLookPlayerDistance);
    }
}
