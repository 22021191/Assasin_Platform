using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public EnemyData data;
    public Rigidbody2D rb2d;

    public Animator anim { get; private set; }
    public string animName { get; private set; }
    public int facingDirection;
    [SerializeField] public DamgeReciver reciver;
    [SerializeField] public DamgeSender sender;
    
    [Header("Check Collider")]
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private Transform groundCheck;
    
    public virtual void Awake()
    {
        anim = GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        rb2d.velocity.Set(velocity, 0);
    }

    public bool WallCheckCollision()
    {
        return Physics2D.OverlapCircle(wallCheck.transform.position,data.wallCheckDistance,data._GroundMask);
        
    }

    public bool GroundCheckCollision()
    {
        return Physics2D.OverlapCircle(groundCheck.transform.position,data.groundCheckRadius,data._GroundMask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(wallCheck.transform.position, data.wallCheckDistance);
        Gizmos.DrawWireSphere(groundCheck.transform.position, data.groundCheckRadius);
        
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, data.minAgroDistance, data._PlayerMask);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, data.maxAgroDistance, data._PlayerMask);
    }

    public virtual void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    public virtual void ChangeAnim(string AnimName)
    {
        if (animName == AnimName) return;

        anim.ResetTrigger(AnimName);
        animName = AnimName;
        anim.SetTrigger(AnimName);
    }
}
