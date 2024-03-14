using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected int inputX;
    protected int inputY;
    protected bool onGround;
    protected bool isTouchingCeiling;
    protected bool dash;
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        onGround = player.GroundCheck();
        isTouchingCeiling=player.TopCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.jumpState.doubleJump= true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        inputX = player.input.inputX;
        inputY= player.input.inputY;
        dash=player.input.dash;

        if (player.input.jumpInput)
        {
            stateMachine.ChangeState(player.jumpState);
        }else if(!onGround)
        {
            player.airState.StartCoyoteTime();
            stateMachine.ChangeState(player.airState);
        }else if (dash)
        {
            stateMachine.ChangeState(player.dashState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player._rb2d.gravityScale = 1;
    }
}
