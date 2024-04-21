using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack2 : EnemyAttackState
{
    private WizardManager manager;
    private GameObject bullet;
    protected bool isAttack;
    
    public WizardAttack2(WizardManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos, GameObject bullet) : base(enemy, stateMachine, animBoolName, data, attackPos)
    {
        manager = enemy;
        this.bullet = bullet;
    }

    public override void Enter()
    {
        base.Enter();
        isAttack = false;

    }

    public override void AnimationTrigger()
    {
        isAttack = true;
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
    private void TakeDamage()
    {
        manager.Shoot(attackPosition,bullet);
        isAttack = false;
    }
}
