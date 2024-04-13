using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

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

        if (exitState)
        {
            return;
        }

        player._horizontalSpeed = Mathf.MoveTowards(player._horizontalSpeed, data.maxSpeed * inputX, data.acceleration * Time.deltaTime);
        player.SetVelocityX(player._horizontalSpeed);
        player.CheckFlip(inputX);

        if (inputX == 0)
        {
            player.stateMachine.ChangeState(player.idleState);
        }
        else if (player.input.attackInput)
        {
            stateMachine.ChangeState(player.attack);
        }
        else if (player.input.crouchInput)
        {
            stateMachine.ChangeState(player.crouchIdle);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player._rb2d.drag = data._groundLinearDrag;
    }
}
