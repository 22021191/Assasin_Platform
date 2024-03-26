using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStunState : StunState
{
    private PlantEnemy plantEnemy;
    public PlantStunState(PlantEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
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
            stateMachine.ChangeState(plantEnemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
