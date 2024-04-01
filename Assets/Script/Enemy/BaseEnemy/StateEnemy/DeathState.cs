using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    public DeathState(Enemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        enemy.DestroyGameObject();
    }

    public override void Enter()
    {
        enemy.rb2d.gravityScale = 0;
        enemy.GetComponent<Collider2D>().enabled = false;
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
