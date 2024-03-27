using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HammerAttackBase : EnemyAttackState
{
    protected HammerManager hammer;
    protected bool isAttack;

    public HammerAttackBase(HammerManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, UnityEngine.Transform attackPos) : base(enemy, stateMachine, animBoolName, data, attackPos)
    {
        this.hammer= enemy;
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
        isAttack = false;
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void AnimationTrigger()
    {
        isAttack = true;
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        
    }

    
}
