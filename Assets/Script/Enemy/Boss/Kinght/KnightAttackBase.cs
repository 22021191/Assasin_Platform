using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackBase : EnemyAttackState
{
    protected bool isAttack;
    private float finishAttack;
    protected Vector2 sizeAttack;
    protected KnightManager manager;
    public KnightAttackBase(KnightManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos,Vector2 sizeAttack) : base(enemy, stateMachine, animBoolName, data, attackPos)
    {
        manager = enemy;
        this.sizeAttack = sizeAttack;
    }

    public override void Enter()
    {
        base.Enter();
        isAttack = false;

    }

    public override void Exit()
    {
        base.Exit();
        finishAttack = Time.time;
        isAttack = false;

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTrigger()
    {
        isAttack = true;
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (manager.die)
        {
            stateMachine.ChangeState(manager.death);
            return;
        }
        if (_ExitState)
        {
            stateMachine.ChangeState(manager.idle);
            return;
        }
    }
}
