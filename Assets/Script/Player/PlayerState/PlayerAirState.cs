using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState 
{
    private int inputX;
    private bool jumpInput;
    private bool _OnGround;
    private bool canJump;
    private bool coyoteTime;
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckCoyoteTime();

        inputX = player.input.inputX;
        jumpInput = player.input.jumpInput;
        
        if (_OnGround && player._rb2d.velocity.y < 0.1f)
        {
            stateMachine.ChangeState(player.landState);
        } else if (jumpInput && player.jumpState.doubleJump)
        {
            if(!coyoteTime)
            {
                player.jumpState.doubleJump = false;
            }
            stateMachine.ChangeState(player.jumpState);
        } else
        {
            player.CheckFlip(inputX);
            player.SetVelocityX(inputX);
        }

        player.anim.SetFloat("VelocityY", AnimTriggerY());
        player.anim.SetFloat("VelocityX",AnimTriggerX());
        
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

    private float AnimTriggerY()
    {
        if (player._rb2d.velocity.y > 0)
        {
            return 1;
        }else
        {
            return -1;
        }
    }

    private float AnimTriggerX()
    {
        if (player._rb2d.velocity.x != 0)
        {
            return 1;
        }
        else
        {
            return -1;
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

}
