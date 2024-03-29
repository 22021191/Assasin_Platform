using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerJumpState : State
{
    private HammerManager hammer;
    private Vector2 direction=new Vector2(1,1);
    private bool isGround;
    public HammerJumpState(HammerManager enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        this.hammer = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGround = hammer.GroundCheckCollision();
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
            stateMachine.ChangeState(hammer.air);            
        }
        hammer.SetVelocity( direction);

    }
}
