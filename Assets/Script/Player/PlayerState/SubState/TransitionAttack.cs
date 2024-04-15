using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAttack : PlayerAbilityState
{
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
        if(!exitState)
        {
            if (player.input.attackInput)
            {
                stateMachine.ChangeState(player.attack1);
            }
        }
    }
    public override void AnimationFinishTrigger()
    {
        isAbilityDone = true;
    }
}
