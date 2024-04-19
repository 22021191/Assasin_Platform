using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMove : EnemyMoveState
{
    private KnightManager manager;
    private bool longAttack;
    public KnightMove(KnightManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData stateData) : base(enemy, stateMachine, animBoolName, stateData)
    {
        manager = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        longAttack = manager.CheckLongRangeAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        manager.CheckFlip(manager.LookPlayer());
        if (canAttack)
        {
            stateMachine.ChangeState(manager.RandomAttack(manager.closeAttack));
        }
        else if (longAttack)
        {
            stateMachine.ChangeState(manager.RandomAttack(manager.openAttack));
        }
        else if (isTouchWall || !isTouchGround)
        {
            manager.idle.SetFlipAfterIdle(true);
            stateMachine.ChangeState(manager.idle);
        }

    }
}
