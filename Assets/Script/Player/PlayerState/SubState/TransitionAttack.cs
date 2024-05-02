using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TransitionAttack : PlayerAbilityState
{
    private int xInput;
    public TransitionAttack(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        xInput = player.input.inputX;

        if (!exitState)
        {
            if (player.input.attackInput)
            {
                stateMachine.ChangeState(player.attack1);
            }
            else if (xInput != 0)
            {
                stateMachine.ChangeState(player.moveState);
            }
        }
    }
    public override void AnimationFinishTrigger()
    {
        isAbilityDone = true;
    }
}
