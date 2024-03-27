using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{

    private bool flipAfterIdle;
    private float idleTime;
    protected bool canAttack;
    public EnemyIdleState(Enemy enemy, FiniteStateMachine stateMachine, string animBoolName,EnemyData data) : base(enemy, stateMachine, animBoolName,data)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        SetRandomIdleTime();
        canAttack=enemy.CheckCanAttack();
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            enemy.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time>idleTime+startTime)
        {
            _ExitState= true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(data.minIdleTime, data.maxIdleTime);
    }
    public void SetFlipAfterIdle(bool flip) { flipAfterIdle = flip; }
}
