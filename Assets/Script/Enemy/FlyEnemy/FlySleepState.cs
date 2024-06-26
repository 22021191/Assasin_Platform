using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySleepState : State
{
    private bool isLook;
    private FlyEnemy fly;
    public FlySleepState(FlyEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        this.fly = enemy;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isLook = fly.LookPlayer();
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
        if (fly.LookPlayer())
        {
            fly.RotationPlayer(fly.LookPlayer());
            stateMachine.ChangeState(fly.attack);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
