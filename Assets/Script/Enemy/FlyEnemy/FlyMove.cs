using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FlyMove : State
{
    private FlyEnemy fly;
    public FlyMove(FlyEnemy enemy, FiniteStateMachine stateMachine, string animBoolName, EnemyData data) : base(enemy, stateMachine, animBoolName, data)
    {
        fly = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Vector2.Distance((Vector2)fly.transform.position, (Vector2)fly.startPos.position)< 0.1f){
            stateMachine.ChangeState(fly.sleep);
        }
        else if (fly.LookPlayer())
        {
            fly.RotationPlayer(fly.LookPlayer());
            stateMachine.ChangeState(fly.attack);
        }
        else
        {
            fly.transform.position += fly.transform.forward * data.speed * Time.deltaTime;
        }
    }
}
