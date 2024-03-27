using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerManager : BossManager
{
    public HammerIdleState idle {  get; private set; }
    public HammerMoveState move { get; private set; }

    [SerializeField] private List<Transform> attackPos;

    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
        idle = new HammerIdleState(this, stateMachine, "Idle", data);
        move = new HammerMoveState(this, stateMachine,"Move",data);

        closeAttack.Add(new HammerAttack1State(this, stateMachine, "Attack1", data, attackPos[0]));
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void Update()
    {
        base.Update();
    }
    
    
}
