using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack1State : HammerAttackBase
{
    private float coolDownTimer;
    private float timeAttack;
    public HammerAttack1State(HammerManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos,int index) : base(enemy, stateMachine, animBoolName, data, attackPos,index)
    {
        coolDownTimer=data.coolDownTime;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void Enter()
    {
        isAttack = false;
        base.Enter();
        timeAttack = 0;
        
    }

    public override void Exit()
    {
        base.Exit();
        timeAttack = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAttack)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        Collider2D hit = Physics2D.OverlapBox(attackPosition.position, sizeAttack,90, data._PlayerMask);
        if (hit)
        {
            isAttack = false;
            timeAttack = Time.time;
            hammer.sender.Send(hit.transform);
        }
    }
}
