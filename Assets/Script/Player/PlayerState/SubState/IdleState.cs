using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerGroundState
{
    public IdleState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player._horizontalSpeed = Mathf.MoveTowards(player._horizontalSpeed, 0, data.deceleration * Time.deltaTime);

        if (exitState)
        {
            return;
        }

        player.SetVelocityX(player._horizontalSpeed);

        if (inputX!=0)
        {
            stateMachine.ChangeState(player.moveState);
        }
        else if (player.input.attackInput)
        {
            stateMachine.ChangeState(player.attack);
        }
        else if(inputY==-1)
        {
            stateMachine.ChangeState(player.crouchIdle);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
