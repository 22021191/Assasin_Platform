using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardManager : BossManager
{
    public WizardIdle idle;
    public WizardMove move;
    public WizardTeleport teleport;
    public WizardAppear appear;

    public WizardAttack1 attack1;
    public WizardAttack2 attack2;
    public WizardAttack3 attack3;

    [SerializeField] private Vector2 limit;
    [SerializeField] private float size;
    [SerializeField] private List<GameObject> bullets;
    public override void Awake()
    {
        base.Awake();

        idle = new WizardIdle(this, stateMachine, "Idle", data);
        move= new WizardMove(this,stateMachine,"Move",data);
        teleport = new WizardTeleport(this, stateMachine, "Teleport", data,limit);
        appear = new WizardAppear(this, stateMachine, "Appear", data);
        attack1 = new WizardAttack1(this, stateMachine, "Attack1", data, attackPos[0], size);
        attack2 = new WizardAttack2(this, stateMachine, "Attack2",data, attackPos[1], bullets[0]);
        attack3 = new WizardAttack3(this, stateMachine, "Attack3", data, attackPos[2], bullets[1]);

        openAttack = new List<EnemyAttackState>();

        openAttack.Add(attack2);
        openAttack.Add(attack3);

    }

    public override void Start()
    {
        base.Start();
        stateMachine.Initialize(idle);
    }

    public void Shoot(Transform pointShoot,GameObject bullet)
    {
        GameObject bulletPrefab = Instantiate(bullet, pointShoot.position, pointShoot.rotation);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(playerCheck.position, data.maxLookPlayerDistance);
        Gizmos.DrawWireSphere(attackPos[0].transform.position, size);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + Vector3.right * facingDirection * data.maxDistanceAttack);
    }

    public override void ResetData()
    {
        base.ResetData();
        stateMachine.ChangeState(idle);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        GameManager.Instance.won=true;
    }
}
