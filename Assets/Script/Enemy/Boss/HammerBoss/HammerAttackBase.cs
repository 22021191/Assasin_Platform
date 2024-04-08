using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HammerAttackBase : EnemyAttackState
{
    protected HammerManager hammer;
    protected bool isAttack;
    private float finishAttack;
    protected Vector2 sizeAttack;


    public HammerAttackBase(HammerManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data, UnityEngine.Transform attackPos,int index) : base(enemy, stateMachine, animBoolName, data, attackPos)
    {
        this.hammer= enemy;
        sizeAttack = hammer.size[index];
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isAttack = false;
        
    }

    public override void Exit()
    {
        base.Exit();
        finishAttack=Time.time;
        isAttack = false;
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (hammer.die)
        {
            stateMachine.ChangeState(hammer.death);
            return;
        }
        if (_ExitState)
        {
            stateMachine.ChangeState(hammer.idle);
            return;
        }else if (CheckAttackCoolDown()) 
        {
            stateMachine.ChangeState(hammer.jump);
            return;
        }
        
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

    protected bool CheckAttackCoolDown()
    {
        return finishAttack + data.coolDownTime > Time.time;
    }
    
}
