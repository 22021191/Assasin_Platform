using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAirState : BossInAirState
{
    private HammerManager hammer;
    private float finishTime;
    private float coolDownTime;
    private float direction;
    public HammerAirState(HammerManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        this.hammer = enemy;
        coolDownTime=data.coolDownTime;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        direction = hammer.facingDirection;
        hammer.rb2d.gravityScale = 2;
    }

    public override void Exit()
    {
        base.Exit();
        hammer.rb2d.gravityScale = 1;

        if (CheckAirAttack())
        {
            AirAttack();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private bool CheckAirAttack()
    {
        return Time.time > finishTime+coolDownTime;
    }

    private void AirAttack()
    {
        hammer.airAttack.gameObject.SetActive(true);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isGrounded)
        {
            stateMachine.ChangeState(hammer.idle);
        }
        else if (isWall)
        {
            enemy.SetVelocityX(0);
        }
        else
        {
            hammer.SetVelocityX(direction*data.speed);
            if(hammer.rb2d.velocity.y<0)
            {
                hammer.rb2d.gravityScale = 7;
            }
            
        }
    }
}
