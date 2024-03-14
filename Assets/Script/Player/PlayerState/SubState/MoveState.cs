using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerGroundState
{
    public MoveState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        player.SetVelocityX(inputX);
        player.CheckFlip(inputX);

        if (inputX == 0)
        {
            player.stateMachine.ChangeState(player.idleState);
        }
        if (inputY == -1)
        {
            stateMachine.ChangeState(player.crouchWalk);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player._rb2d.drag = data._groundLinearDrag;
    }
}
