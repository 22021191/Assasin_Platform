using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardIdle : EnemyIdleState
{
    private WizardManager manager;
    private bool longAttack;
    private bool canTeleport;
    public WizardIdle(WizardManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        manager = enemy;
    }

    
    public override void DoChecks()
    {
        base.DoChecks();
        longAttack = manager.CheckLongRangeAttack();
    }

    public override void Enter()
    {
        base.Enter();
        int tmp = Random.RandomRange(0, 10);
        canTeleport = tmp > 4;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (_ExitState)
        {
            if (canAttack)
            {
                if (canTeleport)
                {
                    stateMachine.ChangeState(manager.teleport);
                }
                else
                {
                    stateMachine.ChangeState(manager.attack1);
                }
            }
            else if (longAttack)
            {
                stateMachine.ChangeState(manager.RandomAttack(manager.openAttack));
            }
            else stateMachine.ChangeState(manager.move);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
