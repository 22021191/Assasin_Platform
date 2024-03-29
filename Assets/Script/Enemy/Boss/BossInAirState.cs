using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInAirState : State
{
    protected bool isGrounded;
    public BossInAirState(Enemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = enemy.GroundCheckCollision();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
