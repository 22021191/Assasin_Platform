using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class StunState : State
{
   
    protected bool isGrounded;
    protected bool canAttack;
    protected bool lookPlayer;
        
    public StunState(Enemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
