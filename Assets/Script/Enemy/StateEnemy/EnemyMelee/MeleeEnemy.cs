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

    public override void Update()
    {
        base.Update();
    }

    private void Start()
    {
        stateMachine.Initialize(_idleState);
    }



}
