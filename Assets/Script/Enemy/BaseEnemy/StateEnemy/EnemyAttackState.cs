using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAttackState : State
{
    protected Transform attackPosition;

    public EnemyAttackState(Enemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data,Transform attackPos) : base(enemy, stateMachine, animBoolName,data)
    {
        this.attackPosition = attackPos;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        enemy.SetVelocityX(0f);
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void TriggerAttack()
    {

    }

}
