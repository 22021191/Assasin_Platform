using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightManager : BossManager
{
    public KnightMove move;
    public KnightIdle idle;
    public KnightJump jump;
    public KnightInAir air;
    public KnightHeath heath;

    public KnightAttack1 attack1;
    public KnightAttack2 attack2;
    public KnightAttack3 attack3;
    public KnightAttack1 jumpAttack;

    public List<Vector3> size;
    [SerializeField] private GameObject bullet;

    public override void Awake()
    {
        base.Awake();

        move = new KnightMove(this, stateMachine, "Move", data);
        idle = new KnightIdle(this, stateMachine, "Idle", data);
        jump = new KnightJump(this, stateMachine, "Jump", data);
        air = new KnightInAir(this, stateMachine, "Jump", data);
        heath=new KnightHeath(this, stateMachine,"Heath",data);
        attack1 = new KnightAttack1(this, stateMachine, "Attack1", data, attackPos[0], size[0]);
        attack2 = new KnightAttack2(this, stateMachine, "Attack2", data, attackPos[1], size[1]);
        attack3=new KnightAttack3(this,stateMachine,"Attack3",data, attackPos[2], size[2]);
        jumpAttack = new KnightAttack1(this, stateMachine, "JumpAttack", data, attackPos[3], size[3]);

        openAttack = new List<EnemyAttackState>();
        closeAttack = new List<EnemyAttackState>();

        closeAttack.Add(attack1);
        openAttack.Add(attack2);
        openAttack.Add(attack3);
    }

    public override void Start()
    {
        base.Start();
        stateMachine.Initialize(idle);
    }
    
    public void Shoot(Transform pointShoot)
    {
        GameObject bulletPrefab = Instantiate(bullet, pointShoot.position, pointShoot.rotation);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(transform.position, data.maxLookPlayerDistance);
        Gizmos.color= Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * facingDirection * data.maxDistanceAttack);
    }
}
