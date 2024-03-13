using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected int inputX;
    protected bool onGround;
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        onGround = player.GroundCheck();
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

        if (player.input.jumpInput)
        {
            stateMachine.ChangeState(player.jumpState);
        }else if(!onGround)
        {
            player.airState.StartCoyoteTime();
            stateMachine.ChangeState(player.airState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
