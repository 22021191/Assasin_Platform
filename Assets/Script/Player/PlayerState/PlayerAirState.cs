using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    //Input
    private int xInput;
    private bool jumpInput;
    private bool jumpInputStop;
    private bool dashInput;

    //Checks
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingWallBack;
    
    private bool isTouchingLedge;

    private bool coyoteTime;
    private bool isJumping;

    public PlayerAirState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.GroundCheck();
        isTouchingWall = player.WallFrontCheck();
        isTouchingWallBack = player.WallCheckBack();

    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();

        player._rb2d.gravityScale = 1;
        player._rb2d.drag = 1;

        isTouchingWall = false;
        isTouchingWallBack = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();
        
        xInput = player.input.inputX;
        jumpInput = player.input.jumpInput;
        dashInput = player.input.dashInput;
        if (player.input.attackInput)
        {
            stateMachine.ChangeState(player.attack);
        }
        else if (isGrounded && player._rb2d.velocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.landState);
        }
        else if (jumpInput && (isTouchingWall || isTouchingWallBack ))
        {
            isTouchingWall = player.WallFrontCheck();
            player.wallJumpState.WallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.wallJumpState);
        }
        else if (jumpInput && coyoteTime)
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else if (jumpInput && player.jumpState.doubleJump)
        {
            player.jumpState.doubleJump = false;
            stateMachine.ChangeState(player.jumpState);
        }       
        else if (isTouchingWall && xInput == player.facingRight && player._rb2d.velocity.y <= 0)
        {
            stateMachine.ChangeState(player.wallSliceState);
        }
        else if (dashInput && player.dashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.dashState);
        }
        else
        {
            player.CheckFlip(xInput);
            player.SetVelocityX(data.maxSpeed*xInput);

        }

    }

   

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player._rb2d.drag = data.airLinearDrag;

        if (player._rb2d.velocity.y < 0)
        {
            player._rb2d.gravityScale = data.fallMultiplier;
        }
        else
        {
            player._rb2d.gravityScale = data.jumpMultiplier;
        }
    }

    private void CheckCoyoteTime()
    {
        if (coyoteTime && Time.time > startTime + data.coyoteTime)
        {
            coyoteTime = false;
            
        }
    }

    
    public void StartCoyoteTime() => coyoteTime = true;
    public void SetIsJumping() => isJumping = true;
}
