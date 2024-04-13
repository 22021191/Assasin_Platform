using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefence : PlayerGroundState
{
    public PlayerDefence(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.hp.isDefence = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.hp.isDefence = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (inputY != -1)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }
}
