using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : Enemy
{
    public List<Transform> attackPos;
    public List<EnemyAttackState> closeAttack;
    public List<EnemyAttackState> openAttack;

    [SerializeField] private Slider heathBar;

   
    public override void Awake()
    {
        base.Awake();
        SetHeathBar();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Start()
    {
        base.Start();
        //heathBar.gameObject.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
        //LookPlayer();
        heathBar.value = reciver.hp;
    }

    public bool CheckLongRangeAttack()
    {
        bool result=Physics2D.Raycast(playerCheck.position, transform.right, data.maxDistanceAttack, data._PlayerMask);
        return result;
    }

    public EnemyAttackState RandomAttack(List<EnemyAttackState> listAttack)
    {
        int index=Random.Range(0, listAttack.Count);

        return listAttack[index];
    }

    public Transform LookPlayer()
    {
        Collider2D detectedObjects = Physics2D.OverlapCircle(transform.position, data.maxLookPlayerDistance, data._PlayerMask);
        if(detectedObjects == null) 
        {
            return null;
        }
        return detectedObjects.transform;
    }

    public bool CheckFlip(Transform playerPos)
    {
        if (playerPos == null) return false;
        return (playerPos.transform.position.x - transform.position.x) * facingDirection < 0;
    }

    public void AnimationTrigger()
    {
        stateMachine.currentState.AnimationTrigger();
    }

    public void AnimationFinishTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }

    public void SetVelocity(Vector3 direction)
    {
        rb2d.velocity = direction*data.force;
    }

    public virtual void EnableHeath()
    {
        heathBar.gameObject.SetActive(true);
    }

    public void SetHeathBar()
    {
        heathBar.maxValue = data.maxHealth;
        heathBar.minValue = 0;
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + Vector3.right * facingDirection * data.attackDistance);
        Gizmos.color = Color.red;
       
    }

    public virtual void ResetData()
    {
        reciver.Reborn();
        this.enabled = false;
    }
}
