using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : EnemyAttackState
{
    private MeleeEnemy melee;
    public MeleeAttack(MeleeEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, Transform attackPos) : base(enemy, stateMachine, animBoolName, data, attackPos)
    {
        melee = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        melee.isAttack= true;
    }

    public override void Exit()
    {
        base.Exit();
        TriggerAttack();
        melee.isAttack= false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(_ExitState)
        {           
            melee._idleState.SetFlipAfterIdle(false);
            stateMachine.ChangeState(melee._idleState);
           
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        /*Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, data.attackDistance, data._PlayerMask);

        foreach (Collider2D collider in detectedObjects)
        {
            melee.sender.Send(collider.transform);
        }*/
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        Debug.Log("Ok");
    }
}
