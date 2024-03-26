using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeClimbState : PlayerState
{
    private Vector2 detectedPos;
    private Vector2 cornerPos;
    private Vector2 startPos;
    private Vector2 stopPos;

    private bool isHanging;
    private bool isClimbing;
    private bool jumpInput;
    private bool isTouchingCeiling;
    private bool isAnimationFinished;

    private int xInput;
    private int yInput;

    public LedgeClimbState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        isAnimationFinished = false;
        exitState = false;
        isClimbing= false;
        isHanging = false;

        player.transform.position = detectedPos;
        player.SetVelocityZero();
        player._rb2d.gravityScale = 0;
        cornerPos = player.DetermineCornerPosition();

        startPos.Set(cornerPos.x - (player.facingRight * data.startOffset.x), cornerPos.y - data.startOffset.y);
        stopPos.Set(cornerPos.x + (player.facingRight * data.stopOffset.x), cornerPos.y + data.stopOffset.y);

        player.transform.position=startPos;
    }

    public override void Exit()
    {
        base.Exit();

        if (isClimbing)
        {
            player.transform.position = stopPos;
            isClimbing = false;
        }
        player._rb2d.gravityScale = 1;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            if (isTouchingCeiling)
            {
                stateMachine.ChangeState(player.crouchIdle);
            }
            else
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
        else
        {
            xInput = player.input.inputX;
            yInput = player.input.inputY;
            jumpInput = player.input.jumpInput;

            player.SetVelocityZero();
            player.transform.position = startPos;

            if (xInput == player.facingRight&&isHanging)
            {
                CheckForSpace();
                isClimbing = true;
                player.anim.SetBool("climbLedge", true);
            }
            else if (yInput == -1 && isHanging && !isClimbing)
            {
                stateMachine.ChangeState(player.airState);
            }
            else if (jumpInput && !isClimbing)
            {
                player.wallJumpState.WallJumpDirection(true);
                stateMachine.ChangeState(player.wallJumpState);
            }
        }

    }

    private void CheckForSpace()
    {
        isTouchingCeiling = Physics2D.Raycast(cornerPos + (Vector2.up * 0.015f) + (Vector2.right * player.facingRight * 0.015f), Vector2.up, data.standColliderHeight, data.groundMask);
        
    }

    public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;

    public override void AnimationTrigger() {
        isHanging = true;
        
    }

    public override void AnimationFinishTrigger()
    {
        isAnimationFinished = true;
        player.anim.SetBool("climbLedge", false);
    }


}
