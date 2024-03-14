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
    }

    public override void Exit()
    {
        base.Exit();
        player.SetColliderHeight(data.standColliderHeight);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        
        if (inputX != 0)
        {
            stateMachine.ChangeState(player.crouchWalk);
        }
        else if (inputY != -1 && !isTouchingCeiling)
        {
            stateMachine.ChangeState(player.idleState);
        }
        
    }
}
