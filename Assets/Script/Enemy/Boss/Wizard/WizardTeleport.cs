using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTeleport : State
{
    private Vector2 limit;
    private WizardManager manager;
    private float idleTime;
    private Vector2 newPos;
    private bool isTeleporting;
    public WizardTeleport(WizardManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data,Vector2 limit) : base(enemy, stateMachine, animBoolName, data)
    {
        this.manager = enemy;
        this.limit = limit;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        SetRandom();
        base.Enter();
    }
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        isTeleporting = true;
    }
    public override void Exit()
    {
        base.Exit();
        manager.transform.position= newPos;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time > idleTime + startTime)
        {
            _ExitState = true;
        }

        if (_ExitState)
        {
            stateMachine.ChangeState(manager.appear);
        }else if (isTeleporting)
        {
            manager.GetComponent<Collider2D>().enabled = false;
            manager.rb2d.gravityScale = 0;
        }
    }

    private void SetRandom()
    {
        idleTime = Random.Range(data.minIdleTime*4, data.maxIdleTime*4);
        float x=Random.Range(limit.x, limit.y);
        newPos=new Vector2(x,manager.transform.position.y);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
