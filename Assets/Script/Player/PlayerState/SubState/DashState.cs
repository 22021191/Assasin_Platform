using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerAbilityState
{
    private bool isHolding;
    private bool dashInputStop;

    private float lastDashTime;

    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;

    public DashState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        player.input.UseDashInput();

        isHolding = true;
        dashDirection = Vector2.right * player.facingRight;

        Time.timeScale = data.holdTimeScale;
        startTime = Time.unscaledTime;

        player.dashDirectionObj.gameObject.SetActive(true);

    }

    public override void Exit()
    {
        base.Exit();

        if (player._rb2d.velocity.y > 0)
        {
            player.SetVelocityY(player._rb2d.velocity.y * data.dashEndYMultiplier);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!exitState)
        {

            if (isHolding)
            {
                dashDirectionInput = player.input.DashDirectionInput(player.facingRight);
                dashInputStop = player.input.DashStop();

                if (dashDirectionInput != Vector2.zero)
                {
                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
                player.dashDirectionObj.transform.rotation = Quaternion.Euler(0f, 0f, angle);

                if (dashInputStop || Time.unscaledTime >= startTime + data.maxHoldTime)
                {
                    isHolding = false;
                    Time.timeScale = 1f;
                    startTime = Time.time;
                    player.CheckFlip(Mathf.RoundToInt(dashDirection.x));
                    player._rb2d.drag = data.dashDrag;
                    player.SetVelocity(data.dashSpeed,dashDirection);
                    player.dashDirectionObj.gameObject.SetActive(false);
                    
                }
            }
            else
            {
                player.SetVelocity(data.dashSpeed, dashDirection);
                
                if (Time.time >= startTime + data.dashLength)
                {
                    player._rb2d.drag = 0f;
                    isAbilityDone = true;
                    lastDashTime = Time.time;
                }
            }
        }
    }

    
    public bool CheckIfCanDash()
    {
        return Time.time >= lastDashTime + data.dashCounter;
    }

}
