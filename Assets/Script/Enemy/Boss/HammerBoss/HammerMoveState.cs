using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMoveState : EnemyMoveState
{

    private HammerManager hammer;
    private bool openAttack;
    public HammerMoveState(HammerManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData stateData) : base(enemy, stateMachine, animBoolName, stateData)
    {
        this.hammer = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        openAttack = hammer.CheckLongRangeAttack();
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

        hammer.CheckFlip(hammer.LookPlayer());
        if (canAttack )
        {
            stateMachine.ChangeState(hammer.RandomAttack(hammer.closeAttack));
        }else if (openAttack)
        {
            stateMachine.ChangeState(hammer.RandomAttack(hammer.openAttack));
        }
        else if (isTouchWall || !isTouchGround)
        {
            hammer.idle.SetFlipAfterIdle(true);
            stateMachine.ChangeState(hammer.idle);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
