using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KnightJump : State
{
    private KnightManager manager;
    private Vector3 direction = new Vector3(1, 2,0);
    private bool isGround;
    public KnightJump(KnightManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        manager = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGround = manager.GroundCheckCollision();
    }

    public override void Enter()
    {
        base.Enter();
        
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isGround)
        {
            stateMachine.ChangeState(manager.air);
        }
        manager.SetVelocity(direction);

    }
}
