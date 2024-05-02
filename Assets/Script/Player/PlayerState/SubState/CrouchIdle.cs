using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CrouchIdle : PlayerGroundState
{
    public CrouchIdle(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetColliderHeight(data.crouchColliderHeight);
        player.collectItem=true;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetColliderHeight(data.standColliderHeight);
        player.collectItem=false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!player.input.crouchInput && !isTouchingCeiling)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
