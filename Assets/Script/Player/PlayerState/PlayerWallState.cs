using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallState : PlayerState
{
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected int inputX;
    protected int inputY;
    protected bool jumpInput;

    public PlayerWallState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.GroundCheck();
        isTouchingWall = player.WallFrontCheck();
        

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
        inputX = player.input.inputX;
        inputY = player.input.inputY;
        jumpInput = player.input.jumpInput;
        if(player.input.dashInput)
        {
            player.input.dashInput = false;
        }

        if (jumpInput)
        {
            player.wallJumpState.WallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.wallJumpState);
        }
        else if (isGrounded)
        {
            stateMachine.ChangeState(player.idleState);
        }
        else if (!isTouchingWall || (inputX != player.facingRight))
        {
            stateMachine.ChangeState(player.airState);
        }
       
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
