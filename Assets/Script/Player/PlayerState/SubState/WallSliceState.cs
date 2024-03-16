using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSliceState : PlayerWallState
{
    public WallSliceState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (exitState)
        {
            return;
        }

        player.SetVelocityY(-data.sliceSpeed);
        if(grabInput&&inputY==0)
        {
            stateMachine.ChangeState(player.wallGrabState);
        }
    }
}
