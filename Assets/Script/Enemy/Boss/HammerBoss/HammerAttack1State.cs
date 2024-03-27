using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack1State : HammerAttackBase
{
    private Vector2 sizeAttack;
    private float coolDownTimer;
    public HammerAttack1State(HammerManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos) : base(enemy, stateMachine, animBoolName, data, attackPos)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
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

    private void TakeDamage()
    {
        Collider2D hit = Physics2D.OverlapBox(attackPosition.position, sizeAttack, 90, data._PlayerMask);
        if (hit && Time.time >= startTime + coolDownTimer)
        {
            startTime = Time.time;
            //hammer.sender.Send(hit.transform);
        }
    }
}
