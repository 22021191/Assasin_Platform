using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerAbilityState
{
    private int xInput;
    private Weapon weapon;
    private bool _OnGround;
    private int curCombo;
    
    public AttackState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        weapon = player.weapon;
        weapon.EnterWeapon();
        _OnGround = player.GroundCheck();
        if (player.input.canNextCombo)
        {
            curCombo=(curCombo+1)>data.comboCount?1:curCombo+1;
        }
        //player.anim.SetBool("AirAttack", !_OnGround);
        player.anim.SetBool("AttackCombo" + curCombo,true);
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("AttackCombo" + curCombo, false);
        weapon.ExitWeapon();
        player.input.attackInputStartTime=Time.time;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!exitState)
        {
            xInput = player.input.inputX;
            player.CheckFlip(xInput);
            player.SetVelocityX(3 * xInput);

        }
    }


    public override void AnimationFinishTrigger()
    {
        isAbilityDone = true;
    }
}
