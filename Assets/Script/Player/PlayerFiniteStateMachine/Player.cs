using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("PlayerData")]
    [SerializeField] private Data data;

    #region Value
    [Header("Component")]
    public Rigidbody2D _rb2d;
    public CapsuleCollider2D collider;
    private DamgeReciver hp;
    public Ghost ghost;

    [Header("Check Value")]
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private GameObject topCheck;
    [SerializeField] private GameObject wallCheck;
    [SerializeField] private GameObject ledgeCheck;

    [Header("Variable")]
    private Vector2 workSpace;
    private Vector2 curVerlocity;
    [SerializeField] private string changeAnimName;
    public int facingRight;
    public float _horizontalSpeed;
    public PlayerInput input;
    public Animator anim { get;private set; }
    public Weapon weapon;

    [SerializeField] private Slider heathBar;
    #endregion

    #region State Value
    [Header("StateMachine")]
    public PlayerStateMachine stateMachine;

    [Header("Player State")]
    public IdleState idleState;
    public MoveState moveState;
    public PlayerAirState airState;
    public JumpState jumpState;
    public LandState landState;
    public CrouchIdle crouchIdle;
    public CrouchWalk crouchWalk;
    public DashState dashState;
    public WallClimbState wallClimbState;
    public WallSliceState wallSliceState;
    public WallGrabState wallGrabState;
    public WallJumpState wallJumpState;
    public LedgeClimbState ledge;
    public AttackState attack;
    public PlayerDeathState death;
    #endregion

    private void Awake()
    {
        //Khoi tao Component
        anim = GetComponent<Animator>();
        _rb2d= GetComponent<Rigidbody2D>();
        input= GetComponent<PlayerInput>();
        collider = GetComponent<CapsuleCollider2D>();
        ghost= GetComponent<Ghost>();

        //Khoi tao StateMachine
        stateMachine =new PlayerStateMachine();

        //Khoi tao Player State
        idleState=new IdleState(this,stateMachine,data,"Idle");
        moveState = new MoveState(this, stateMachine, data, "Move");
        airState = new PlayerAirState(this, stateMachine, data, "Jump");
        jumpState = new JumpState(this, stateMachine, data, "Jump");
        landState = new LandState(this, stateMachine, data, "Land");
        crouchIdle = new CrouchIdle(this, stateMachine, data, "CrouchIdle");
        crouchWalk = new CrouchWalk(this, stateMachine, data, "CrouchWalk");
        dashState = new DashState(this, stateMachine, data, "Dash");
        wallClimbState = new WallClimbState(this, stateMachine, data, "Climb");
        wallGrabState = new WallGrabState(this, stateMachine, data, "Grab");
        wallSliceState = new WallSliceState(this, stateMachine, data, "Slice");
        wallJumpState = new WallJumpState(this, stateMachine, data, "WallJump");
        ledge = new LedgeClimbState(this, stateMachine, data, "Ledge");
        attack = new AttackState(this, stateMachine, data, "Attack");
        death = new PlayerDeathState(this, stateMachine, data, "Death");
    }

    void Start()
    {
        stateMachine.Initialize(idleState);
        hp = GetComponent<DamgeReciver>();
        heathBar.maxValue=hp.hpMax;
        heathBar.minValue = 0;
    }

    
    void Update()
    {
        curVerlocity=_rb2d.velocity;
        stateMachine.CurrentState.LogicUpdate();
        heathBar.value = hp.hp;

        if (hp.hp <= 0)
        {
            stateMachine.ChangeState(death);
        }
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }
    #region Set Function
    public void SetVelocityY(float force)
    {
        workSpace.Set(curVerlocity.x, force);
        _rb2d.velocity = workSpace;
        curVerlocity = _rb2d.velocity;
    }

    public void SetVelocityX(float speed)
    {
        workSpace.Set(speed, curVerlocity.y);
        _rb2d.velocity = workSpace;
        curVerlocity = workSpace;
    }

    public void SetVelocityZero()
    {
        _rb2d.velocity = Vector2.zero;
        curVerlocity= Vector2.zero;

    }

    public void SetColliderHeight(float height)
    {
        Vector2 center = collider.offset;
        workSpace.Set(collider.size.x, height);

        center.y += (height - collider.size.y) / 2;

        collider.size = workSpace;
        collider.offset = center;
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workSpace = direction * velocity;
        _rb2d.velocity = workSpace;
        curVerlocity = workSpace;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        _rb2d.velocity = workSpace;
        curVerlocity = workSpace;
    }
    #endregion

    #region Check Functions
    public void CheckFlip(int inputX)
    {
        if(inputX != 0&&inputX!=facingRight) 
        {
            Flip();
        }
    }

    public bool LedgeCheck()
    {
        return Physics2D.Raycast(ledgeCheck.transform.position, Vector2.right * facingRight, data.ledgeDistance, data.groundMask);
    }

    public bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheck.transform.position, data.groundRadius, data.groundMask);
    }

    public bool WallFrontCheck()
    {
        return Physics2D.Raycast(wallCheck.transform.position, Vector2.right * facingRight, data.wallDistance,data.groundMask);

    }

    public bool WallCheckBack()
    {
        return Physics2D.Raycast(wallCheck.transform.position, Vector2.right * -1*facingRight, data.wallDistance, data.groundMask);

    }
    public bool TopCheck()
    {
        return Physics2D.OverlapCircle(topCheck.transform.position, data.groundRadius, data.groundMask);
    }
    #endregion

    #region Other Functions

    public void EnableControls()
    {
        input.enabled = true;
    }
    public void DisableControls()
    {
        input.enabled = false;
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject,1f);
    }

    private void Flip()
    {
        facingRight *= -1;
        transform.Rotate(0, 180, 0);
    }

    public Vector2 DetermineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(wallCheck.transform.position, Vector2.right * facingRight, data.wallDistance, data.groundMask);
        float xDist = xHit.distance;
        workSpace.Set((xDist + 0.015f) * facingRight, 0f);
        RaycastHit2D yHit = Physics2D.Raycast(ledgeCheck.transform.position + (Vector3)(workSpace), Vector2.down, ledgeCheck.transform.position.y - wallCheck.transform.position.y + 0.015f, data.groundMask);
        float yDist = yHit.distance;

        workSpace.Set(wallCheck.transform.position.x + (xDist * facingRight), ledgeCheck.transform.position.y - yDist);
        return workSpace;
    }

    private void AnimationTrigger()
    {
        stateMachine.CurrentState.AnimationTrigger();
        
    }

    private void AnimtionFinishTrigger()
    {
        stateMachine.CurrentState.AnimationFinishTrigger();
        
    }

    public void ChangeAnim(string AnimName)
    {
        if (changeAnimName == AnimName) return;

        anim.ResetTrigger(AnimName);
        changeAnimName = AnimName;
        anim.SetTrigger(AnimName);
    }
    #endregion
}
