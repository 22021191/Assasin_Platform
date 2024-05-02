using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerAbilityState
{
    private float lastDashTime;

    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;

    public DashState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.gameObject.layer = LayerMask.NameToLayer("Dash");
        player.input.UseDashInput();
        player.ghost.makeGhost = true;

        dashDirection = Vector2.right * player.facingRight;

        dashDirectionInput = player.input.DashDirectionInput(player.facingRight);
        if (dashDirectionInput != Vector2.zero)
        {
            dashDirection = dashDirectionInput;
            dashDirection.Normalize();
        }
        float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
        Time.timeScale = 1f;
        startTime = Time.time;
        player.CheckFlip(Mathf.RoundToInt(dashDirection.x));
        player.SetVelocity(data.dashSpeed, dashDirection);
        AudioManager.Instance.PlaySfx("Dash");
    }

    public override void Exit()
    {
        base.Exit();

        player.gameObject.layer = LayerMask.NameToLayer("Player");
        player.ghost.makeGhost= false;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!exitState)
        {                                 
            player.SetVelocity(data.dashSpeed, dashDirection);
                
            if (Time.time >= startTime + data.dashLength)
            {
                player._rb2d.drag = 0f;
                isAbilityDone = true;
                lastDashTime = Time.time;
            }
            player.ghost.MakeGhostRender();
            
        }
    }

    
    public bool CheckIfCanDash()
    {
        return Time.time >= lastDashTime + data.dashCounter;
    }

}
