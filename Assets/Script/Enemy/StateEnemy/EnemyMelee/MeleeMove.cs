using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMove : EnemyMoveState
{
    private MeleeEnemy melee;
    public MeleeMove(MeleeEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData stateData) : base(enemy, stateMachine, animBoolName, stateData)
    {
        melee = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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
        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(melee._attackState);
        }
        else if (isTouchWall || !isTouchGround)
        {
            melee._idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(melee._idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
