using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack2 : KnightAttackBase
{
    
    public KnightAttack2(KnightManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos, Vector2 sizeAttack) : base(enemy, stateMachine, animBoolName, data, attackPos, sizeAttack)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAttack)
        {
            TakeDamage();
            manager.SetVelocityX(data.speed * 2);
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
