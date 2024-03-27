using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyMoveState :State
{
    protected EnemyData stateData;

    protected bool isTouchWall;
    protected bool isTouchGround;
    protected bool canAttack;

    public EnemyMoveState(Enemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData stateData) : base(enemy, stateMachine, animBoolName,stateData)
    {
       
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isTouchGround = enemy.GroundCheckCollision();
        isTouchWall = enemy.WallCheckCollision();
        canAttack = enemy.CheckCanAttack();
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocityX(data.speed*enemy.facingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemy.SetVelocityX(data.speed * enemy.facingDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
