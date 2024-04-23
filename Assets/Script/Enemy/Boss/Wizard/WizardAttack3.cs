using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack3 : EnemyAttackState
{
    private WizardManager manager;
    private GameObject bullet;
    protected bool isAttack;
    public float finish;

    public WizardAttack3(WizardManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos, GameObject bullet) : base(enemy, stateMachine, animBoolName, data, attackPos)
    {
        manager = enemy;
        this.bullet = bullet;
    }

    public override void Enter()
    {
        base.Enter();
        if(finish+4>Time.time)
        {
            stateMachine.ChangeState(manager.attack2);
        }
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
        manager.Shoot(attackPosition, bullet);
        isAttack = false;
        finish = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
