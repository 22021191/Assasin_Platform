using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState :PlayerAbilityState
{
    private bool _OnGround;
    public bool doubleJump;

    public JumpState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        _OnGround = player.GroundCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(data.jumpForce);
        player.jumpDust.Play();
        isAbilityDone = true;
        AudioManager.Instance.PlaySfx("Jump");
    }

    public override void Exit()
    {
        base.Exit();
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
