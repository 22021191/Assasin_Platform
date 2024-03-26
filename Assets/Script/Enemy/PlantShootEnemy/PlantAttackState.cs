using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttackState : EnemyAttackState
{
    private PlantEnemy plantEnemy;
    public PlantAttackState(PlantEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos) : base(enemy, stateMachine, animBoolName, data, attackPos)
    {
        plantEnemy = enemy;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        TriggerAttack();
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

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        plantEnemy.Shoot();
    }
}
