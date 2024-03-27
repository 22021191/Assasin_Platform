using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : Enemy
{
    public Transform playerPos {  get; private set; }
    public List<EnemyAttackState> closeAttack;
    public List<EnemyAttackState> openAttack;
    public List<Transform> attackPos; 


    public override void Awake()
    {
        base.Awake();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        LookPlayer();
    }

    public bool CheckLongRangeAttack()
    {
        bool result=Physics2D.Raycast(playerCheck.position, transform.right, data.maxDistanceAttack, data._PlayerMask);
        return result&&!CheckCanAttack();
    }

    public EnemyAttackState RandomAttack(List<EnemyAttackState> listAttack)
    {
        int index=Random.Range(0, listAttack.Count);

        return listAttack[index];
    }

    public void LookPlayer()
    {
        Collider2D detectedObjects = Physics2D.OverlapCircle(transform.position, data.maxLookPlayerDistance, data._PlayerMask);
        playerPos = detectedObjects.transform;
    }

    public void CheckFlip()
    {
        if ((playerPos.transform.position.x - transform.position.x) * facingDirection < 0)
        {
            Flip();
        }
    }
}
