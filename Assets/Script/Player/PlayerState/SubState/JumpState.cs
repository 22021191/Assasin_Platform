using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState :PlayerState
{
    private bool _OnGround;
    public bool doubleJump;
    public JumpState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        _OnGround = player.GroundCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(data.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(_OnGround&player._rb2d.velocity.y<0.1f) 
        {
            stateMachine.ChangeState(player.idleState);
        }
        else
        {
            stateMachine.ChangeState(player.airState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
