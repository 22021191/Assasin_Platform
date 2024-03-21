using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeIdle : EnemyIdleState
{
    private MeleeEnemy melee;
    public MeleeIdle(MeleeEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        melee= enemy;
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
        if (_ExitState)
        {
            if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(melee._attackState);
            }
            else
            {
                stateMachine.ChangeState(melee._moveState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
