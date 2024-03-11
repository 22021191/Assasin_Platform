using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected Data data;
    protected float startTime;

    private string animName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, Data playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.data = playerData;
        this.animName = animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animName, true);
        startTime= Time.time;
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        
    }



}
