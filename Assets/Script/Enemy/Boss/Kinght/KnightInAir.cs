using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightInAir : BossInAirState
{
    private KnightManager manager;
    private float direction;

    public KnightInAir(KnightManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        manager = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        direction = manager.facingDirection;
        manager.rb2d.gravityScale = 2;
        manager.anim.SetFloat("VelocityY", 0);

    }

    public override void Exit()
    {
        base.Exit();
        manager.rb2d.gravityScale = 1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isGrounded)
        {
            stateMachine.ChangeState(manager.jumpAttack);
        }
        else if (isWall)
        {
            enemy.SetVelocityX(0);
        }
        else
        {
            manager.SetVelocityX(direction * data.speed);
            if (manager.rb2d.velocity.y < 0)
            {
                manager.anim.SetFloat("VelocityY", 1);
                manager.rb2d.gravityScale = 7;
            }

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
