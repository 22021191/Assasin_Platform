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
       
    }

    public override void Exit()
    {
        base.Exit();
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

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isGrounded)
        {
           
            if (CheckAirAttack())
            {
                AirAttack();
            }
            stateMachine.ChangeState(hammer.idle);
        }
        else
        {
            hammer.SetVelocityX(direction*data.speed);
            
        }
    }
}
