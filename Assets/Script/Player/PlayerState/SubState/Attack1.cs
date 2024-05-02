using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : PlayerAbilityState
{
    private int xInput;
    private Weapon weapon;
    private bool _OnGround;

    public Attack1(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        weapon = player.weapon;
        weapon.EnterWeapon();
        AudioManager.Instance.PlaySfx("Sword");

        _OnGround = player.GroundCheck();
    }

    public override void Exit()
    {
        base.Exit();
        weapon.ExitWeapon();
        player.input.attackInputStartTime = Time.time;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        

    }

    public override void AnimationFinishTrigger()
    {
        isAbilityDone = true;
    }
}
