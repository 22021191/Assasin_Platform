using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerIdleState : EnemyIdleState
{
    private HammerManager hammer;
    private bool openAttack;
    private bool closeAttack;
    public HammerIdleState(HammerManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        this.hammer = enemy;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        openAttack = hammer.CheckLongRangeAttack();
        closeAttack=hammer.CheckCanAttack();
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
            if (closeAttack)
            {
                stateMachine.ChangeState(hammer.RandomAttack(hammer.closeAttack));
            }
            else if (openAttack)
            {
                stateMachine.ChangeState(hammer.RandomAttack(hammer.openAttack));
            }
            else stateMachine.ChangeState(hammer.move);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
