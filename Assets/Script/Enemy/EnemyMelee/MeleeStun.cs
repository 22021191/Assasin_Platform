using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeStun : StunState
{
    private MeleeEnemy melee;
    public MeleeStun(MeleeEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
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
        if(_ExitState=true)
        {
            return;
        }
        if (!isGrounded||!canAttack)
        {
            melee._idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(melee._idleState);
        }else if (canAttack)
        {
            stateMachine.ChangeState(melee._attackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
