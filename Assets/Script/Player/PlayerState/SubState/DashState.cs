using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerAbilityState
{
    private bool exitDash;
    private bool isGrounded;
    private int inputY;
    private float lastDashTime;

    public DashState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.GroundCheck();
    }

    public override void Enter()
    {
        base.Enter();
        exitDash = false;
        inputY = player.input.inputY;
        lastDashTime = Time.time;

        player._rb2d.velocity = Vector2.zero;
        player._rb2d.gravityScale = 0;
        player._rb2d.drag = 0;
        Time.timeScale = data.dashTimeScale;
    }

    public override void Exit()
    {
        base.Exit();
        Time.timeScale = 1;
        player.input.counter = data.dashCounter;
        player._rb2d.velocity = Vector2.zero;
       
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckExit();

        Vector2 dir = new Vector2(player.facingRight*2, inputY);
        player._rb2d.velocity = dir.normalized * data.dashSpeed;

        if (exitDash)
        {
            isAbilityDone = true;
        }
    }

    public bool CheckIfCanDash()
    {
        return Time.time >= lastDashTime + data.dashCounter;
    }

    private void CheckExit()
    {
        exitDash = startTime + data.dashLength < Time.time;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
