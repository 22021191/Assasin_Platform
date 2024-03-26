using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantIdleState : EnemyIdleState
{
    private PlantEnemy plantEnemy;
    public PlantIdleState(PlantEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        this.plantEnemy = enemy;
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
            stateMachine.ChangeState(plantEnemy.attackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
