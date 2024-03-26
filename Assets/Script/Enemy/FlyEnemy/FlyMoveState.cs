using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMoveState : State
{
    private FlyEnemy fly;
    private bool stopMove;
    private bool lookPlayer;
    public FlyMoveState(FlyEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
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
        stopMove=Vector2.Distance(fly.transform.position,fly.startPos.position)<0.1;
        lookPlayer = fly.LookPlayer();
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

        if (lookPlayer)
        {
            stateMachine.ChangeState(fly.chase);
        }
        else if(stopMove)
        {
            stateMachine.ChangeState(fly.idle);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
