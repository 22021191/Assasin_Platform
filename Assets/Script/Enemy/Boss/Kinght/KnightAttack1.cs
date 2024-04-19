using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack1 : KnightAttackBase
{
    public KnightAttack1(KnightManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos,Vector2 sizeAttack) : base(enemy, stateMachine, animBoolName, data, attackPos,sizeAttack)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
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
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAttack)
        {
            TakeDamage();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    private void TakeDamage()
    {
        Collider2D hit = Physics2D.OverlapBox(attackPosition.position, sizeAttack, 90, data._PlayerMask);
        if (hit)
        {
            isAttack = false;
            manager.sender.Send(hit.transform);
        }
    }
}
