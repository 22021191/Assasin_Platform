using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHeath : State
{
    private KnightManager manager;
    public KnightHeath(KnightManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        manager = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        if (manager.reciver.hp < manager.reciver.hpMax)
        {
            manager.reciver.hp += 15;
        }
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
