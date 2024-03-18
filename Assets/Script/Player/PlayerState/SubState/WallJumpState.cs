using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpState : PlayerAbilityState
{
    private int direction;
    private bool isGrounded;
    public WallJumpState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.GroundCheck();
    }

    public override void Enter()
    {
        player.SetVelocity(data.wallJumpVelocity, data.wallAngle, direction);
        player.CheckFlip(direction);
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + data.wallJumpTime)
        {
            isAbilityDone = true;
        }
        
    }

    public void WallJumpDirection(bool isTouchingWall)
    {
        if (isTouchingWall)
        {
            direction = -player.facingRight;
        }
        else
        {
            direction = player.facingRight;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
