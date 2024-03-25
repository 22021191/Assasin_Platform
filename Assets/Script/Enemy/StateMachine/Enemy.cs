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
    public bool isAttack;
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

    public virtual void Start()
    {
        rb2d= gameObject.GetComponent<Rigidbody2D>();
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
        rb2d.velocity=new Vector2(velocity,0);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(wallCheck.transform.position, data.wallCheckDistance);
        Gizmos.DrawWireSphere(groundCheck.transform.position, data.groundCheckRadius);
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + Vector3.right * facingDirection * data.attackDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + Vector3.right * facingDirection * data.maxLookPlayerDistance);

    }

    public virtual bool CheckCanAttack()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, data.attackDistance, data._PlayerMask);
    }

    public bool WallCheckCollision()
    {
        return Physics2D.OverlapCircle(wallCheck.transform.position,data.wallCheckDistance,data._GroundMask);
        
    }

    public bool GroundCheckCollision()
    {
        return Physics2D.OverlapCircle(groundCheck.transform.position,data.groundCheckRadius,data._GroundMask);
    }

    public virtual bool CheckInLookDistance()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, data.maxLookPlayerDistance, data._PlayerMask);
    }

    public virtual void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingDirection *= -1;
    }

    public virtual void ChangeAnim(string AnimName)
    {
        if (animName == AnimName) return;

        anim.ResetTrigger(AnimName);
        animName = AnimName;
        anim.SetTrigger(AnimName);
    }
}
