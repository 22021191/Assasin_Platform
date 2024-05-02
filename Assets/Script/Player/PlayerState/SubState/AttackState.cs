using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerAbilityState
{
    private int xInput;
    private Weapon weapon;
    private bool _OnGround;
    
    public AttackState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        weapon = player.weapon;
        weapon.EnterWeapon();
        _OnGround = player.GroundCheck();
        
    }

    public override void Exit()
    {
        base.Exit();        
        weapon.ExitWeapon();
        player.input.attackInputStartTime=Time.time;
        AudioManager.Instance.PlaySfx("Sword");
    }

    public override void LogicUpdate()
    {
        if(isAbilityDone)
        {
            stateMachine.ChangeState(player.transition);
        }
        
        xInput = player.input.inputX;

        if (xInput != 0)
        {
            player.SetVelocityX(xInput * 4);
        }

    }


    public override void AnimationFinishTrigger()
    {
        isAbilityDone = true;
    }
}
