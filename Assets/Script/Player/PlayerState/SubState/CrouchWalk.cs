using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchWalk : PlayerGroundState
{
    public CrouchWalk(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetColliderHeight(data.crouchColliderHeight);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetColliderHeight(data.standColliderHeight);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityX(inputX*3);
        player.CheckFlip(inputX);

        if (inputX == 0)
        {
            stateMachine.ChangeState(player.crouchIdle);
        }
        else if (inputY != -1 && !isTouchingCeiling)
        {
            stateMachine.ChangeState(player.moveState);
        }

    }
}
