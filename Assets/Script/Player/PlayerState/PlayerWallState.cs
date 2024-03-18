using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallState : PlayerState
{
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected int inputX;
    protected int inputY;
    protected bool grabInput;
    protected bool jumpInput;
    protected bool isTouchingLedge;

    public PlayerWallState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.GroundCheck();
        isTouchingWall = player.WallFrontCheck();
        isTouchingLedge=player.LedgeCheck();

        if (isTouchingWall && !isTouchingLedge)
        {
            player.ledge.SetDetectedPosition(player.transform.position);
        }

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
        grabInput=player.input.grabInput;
        jumpInput = player.input.jumpInput;

        if (jumpInput)
        {
            player.wallJumpState.WallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.wallJumpState);
        }
        else if (isGrounded&&!grabInput)
        {
            stateMachine.ChangeState(player.idleState);
        }
        else if (!isTouchingWall || (inputX != player.facingRight&&!grabInput))
        {
            stateMachine.ChangeState(player.airState);
        }
        else if (isTouchingWall && !isTouchingLedge)
        {
            stateMachine.ChangeState(player.ledge);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
