using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyIdleState : EnemyIdleState
{
    private FlyEnemy fly;
   
    public FlyIdleState(FlyEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
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
            if (fly.LookPlayer())
            {
                fly.RotationPlayer(fly.LookPlayer());
                stateMachine.ChangeState(fly.attack);
            }
            else
            {
                stateMachine.ChangeState(fly.move);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
