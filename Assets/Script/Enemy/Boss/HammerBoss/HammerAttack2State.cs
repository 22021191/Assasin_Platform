using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack2State : HammerAttackBase
{

    public HammerAttack2State(HammerManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos,int index) : base(enemy, stateMachine, animBoolName, data, attackPos,index)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        TriggerAttack();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
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
        TriggerAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        Collider2D hit = Physics2D.OverlapBox(attackPosition.position, sizeAttack, 90, data._PlayerMask);
        if(hit != null)
        {
            hammer.sender.Send(hit.transform);
        }
    }
}
