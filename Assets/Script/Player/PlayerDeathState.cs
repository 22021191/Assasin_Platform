using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        player.DestroyGameObject();
    }

    public override void Enter()
    {
        player._rb2d.gravityScale = 0;
        player.GetComponent<Collider2D>().enabled = false;
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
