using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : PlayerAbilityState
{
    public HurtState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void AnimationFinishTrigger()
    {
        isAbilityDone = true;
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlaySfx("Hurt");
    }

    public override void Exit()
    {
        base.Exit();
        player.curHeath = player.hp.hp;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isAbilityDone)
        {
            if (player.hp.hp <= 0)
            {
                player.curHeath = 0;
                stateMachine.ChangeState(player.death);
            }
        }
    }
}
