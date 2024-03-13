using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState 
{
    private int inputX;
    private bool jumpInput;
    private bool _OnGround;
    private bool canJump;
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
        inputX = player.input.inputX;
        jumpInput = player.input.jumpInput;
        
        if (_OnGround && player._rb2d.velocity.y < 0.1f)
        {
            stateMachine.ChangeState(player.landState);
        }
        else
        {
            player.CheckFlip(inputX);
            player.SetVelocityX(inputX*data.movementVelocity);
        }
        if(jumpInput&&player.jumpState.doubleJump)
        {
            player.jumpState.doubleJump = false;
            stateMachine.ChangeState(player.jumpState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
