using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAppear : State
{
    private WizardManager manager;
    public WizardAppear(WizardManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        manager = enemy;
    }
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void Exit()
    {
        base.Exit();
        manager.GetComponent<Collider2D>().enabled = true;
        manager.rb2d.gravityScale = 1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (_ExitState)
        {
            stateMachine.ChangeState(manager.idle);
        }
    }
}
