using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightIdle :EnemyIdleState
{
    private KnightManager manager;
    private bool longAttack;
    private bool canJump;
    private bool canHeath;
    public KnightIdle(KnightManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        manager = enemy;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        longAttack=manager.CheckLongRangeAttack();
    }

    public override void Enter()
    {
        base.Enter();

        int tmp = Random.RandomRange(0, 10);
        canJump = tmp > 6;
        canHeath = tmp > 8&&manager.reciver.hp<manager.reciver.hpMax;
        _ExitState = false;
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
            if (canHeath&&manager.reciver.hp<manager.reciver.hpMax)
            {
                stateMachine.ChangeState(manager.heath);
            }
            else if (canJump)
            {
                stateMachine.ChangeState(manager.jump);
            }
            else if (canAttack)
            {
                stateMachine.ChangeState(manager.RandomAttack(manager.closeAttack));
            }
            else if (longAttack)
            {
                stateMachine.ChangeState(manager.RandomAttack(manager.openAttack));
            }
            else stateMachine.ChangeState(manager.move);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
