using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class State 
{

    protected FiniteStateMachine stateMachine;
    protected Enemy enemy;
    protected EnemyData data;
    public float startTime { get; protected set; }
    protected string animName;
    protected bool _ExitState;

    public State(Enemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animName = animBoolName;
        this.data = data;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        _ExitState= false;
        enemy.ChangeAnim(animName);
        DoChecks();
    }

    public virtual void Exit()
    {
        
        _ExitState= true;
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
    public virtual void AnimationFinishTrigger() => _ExitState = true;

    public virtual void AnimationTrigger() { }
}
