using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class LandState : PlayerGroundState
{
    public LandState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.jumpDust.Play();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.input.inputX != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
        else
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
