using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class HammerManager : BossManager
{
    public HammerIdleState idle {  get; private set; }
    public HammerAirState air {  get; private set; }
    public HammerJumpState jump { get; private set; }
    public HammerMoveState move { get; private set; }

    private HammerAttack1State attack1;
    private HammerAttack1State attack4;
    private HammerAttack2State meleeAttack2;
    private HammerAttack2State meleeAttack3;

    [SerializeField] private GameObject wallBattle1, wallBattle2;
    public List<Vector3> size;
    public Explosion airAttack;
    
    public override void Awake()
    {
        base.Awake();
        
        idle = new HammerIdleState(this, stateMachine, "Idle", data);
        move = new HammerMoveState(this, stateMachine,"Move",data);
        jump = new HammerJumpState(this, stateMachine, "Jump", data);
        air = new HammerAirState(this, stateMachine, "Jump", data);

        attack1 = new HammerAttack1State(this, stateMachine, "Attack1", data, attackPos[0],0);
        attack4 = new HammerAttack1State(this, stateMachine, "Attack4", data, attackPos[3],3);
        meleeAttack2 = new HammerAttack2State(this, stateMachine, "Attack2", data, attackPos[1],1);
        meleeAttack3 = new HammerAttack2State(this, stateMachine, "Attack3", data, attackPos[2],2);

        openAttack = new List<EnemyAttackState>();
        closeAttack = new List<EnemyAttackState>();


        openAttack.Add(attack4);
        openAttack.Add(attack1);

        closeAttack.Add(meleeAttack3);
        closeAttack.Add(attack4);
        closeAttack.Add(meleeAttack2);
    }
    public override void Start()
    {
        base.Start();
        stateMachine.Initialize(idle);

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void Update()
    {
        base.Update();
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(transform.position, data.maxLookPlayerDistance);
        Gizmos.color = Color.yellow;
        for(int i=0;i<size.Count; i++)
        {
            Gizmos.DrawWireCube(attackPos[i].position, size[i]);
        }
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + Vector3.right * facingDirection * data.maxDistanceAttack);
    }

    public override void EnableHeath()
    {
        base.EnableHeath();
        wallBattle1.SetActive(true);
        wallBattle2.SetActive(true);
    }

    public override void ResetData()
    {
        base.ResetData();   
        wallBattle1.SetActive(false);
        stateMachine.ChangeState(idle);
        gameObject.GetComponent<DialogueTrigger>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.layer = LayerMask.NameToLayer("Npc");

    }
}
