using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack1 : EnemyAttackState
{
    private WizardManager manager;
    private float size;
    private bool isAttack;
    public WizardAttack1(WizardManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos,float size) : base(enemy, stateMachine, animBoolName, data, attackPos)
    {
        manager = enemy;
        this.size = size;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (manager.die)
        {
            stateMachine.ChangeState(manager.death);
            return;
        }
        if (_ExitState)
        {
            stateMachine.ChangeState(manager.idle);
            return;
        }
        if (isAttack)
        {
            TakeDamage();
        }
    }

    public override void AnimationTrigger()
    {
        isAttack = true;
    }

    private void TakeDamage()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPosition.position, size, data._PlayerMask);
        if (hit)
        {
            isAttack = false;
            manager.sender.Send(hit.transform);
        }
    }
}
