using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGrabState : PlayerWallState
{
    public WallGrabState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (exitState)
        {
            return;
        }

        player._rb2d.velocity = Vector2.zero;
        if (inputY > 0)
        {
            stateMachine.ChangeState(player.wallClimbState);
        }
        else if (inputY < 0 || !grabInput)
        {
            stateMachine.ChangeState(player.wallSliceState);
        }
    }
}
