using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbState : PlayerWallState
{
    public WallClimbState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (exitState)
        {
            return;
        }

        player.SetVelocityY(data.climdSpeed);
        if (inputY != 1)
        {
            stateMachine.ChangeState(player.wallGrabState);
        }
    }
}
