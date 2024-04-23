using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAttackState : EnemyAttackState
{
    private FlyEnemy fly;
    
    public FlyAttackState(FlyEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos) : base(enemy, stateMachine, animBoolName, data, attackPos)
    {
        this.fly = enemy;
       
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
        startTime = Time.time;  
    }

    public override void Exit()
    {
        base.Exit();
        fly.rb2d.velocity = Vector2.zero;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(startTime+1<Time.time)
        {
            stateMachine.ChangeState(fly.idle);
        }
        else
        {
            fly.SetVelocity(fly.direction);
            TakeDamge();
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
    private void TakeDamge()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPosition.position, data.attackDistance, 90, data._PlayerMask);
        if (hit)
        {
            fly.sender.Send(hit.transform);
        }
    }
}
