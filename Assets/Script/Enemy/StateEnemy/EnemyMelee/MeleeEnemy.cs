using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [Header("Enemy State")]
    public MeleeIdle _idleState;
    public MeleeAttack _attackState;
    public MeleeMove _moveState;

    [Header("Other Value")]
    [SerializeField] private Transform attackPos;

    public override void Awake()
    {
        base.Awake();
        _idleState = new MeleeIdle(this, stateMachine, "Idle", data);
        _attackState = new MeleeAttack(this, stateMachine, "Attack", data,attackPos);
        _moveState = new MeleeMove(this, stateMachine, "Move", data);

    }
    public override void Start()
    {
        base.Start();
        stateMachine.Initialize(_idleState);
        reciver.hpMax = data.maxHealth;
        reciver.Reborn();
    }

    public override void Update()
    {
        base.Update();
    }

    public void AnimationFinishTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackPos.transform.position, data.attackDistance);
    }
}
