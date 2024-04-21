using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack1 : EnemyAttackState
{
    private WizardManager manager;
    private Vector2 size;
    private bool isAttack;
    public WizardAttack1(WizardManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos,Vector2 size) : base(enemy, stateMachine, animBoolName, data, attackPos)
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
        Collider2D hit = Physics2D.OverlapBox(attackPosition.position, size, 90, data._PlayerMask);
        if (hit)
        {
            isAttack = false;
            manager.sender.Send(hit.transform);
        }
    }
}
