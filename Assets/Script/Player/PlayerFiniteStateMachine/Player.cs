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
    public BoxCollider2D collider;
    public DamgeReciver hp;
    public Ghost ghost;
    public ParticleSystem dustMove;
    public ParticleSystem jumpDust;
    public ParticleSystem slideDust;

    [Header("Check Value")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform topCheck;
    [SerializeField] private Transform wallCheck;


    [Header("Variable")]
    private Vector2 workSpace;
    private Vector2 curVerlocity;
    [SerializeField] private string changeAnimName;
    public int facingRight;
    public float _horizontalSpeed;
    public PlayerInput input;
    public Animator anim { get;private set; }
    public Weapon weapon;
    public int curHeath;

    [SerializeField] private Slider heathBar;
    [SerializeField] private Slider defBar;
    #endregion

    #region State Value
    [Header("StateMachine")]
    public PlayerStateMachine stateMachine;

    [Header("Player State")]
    public IdleState idleState;
    public MoveState moveState;
    public PlayerAirState airState;
    public HurtState hurt;
    public JumpState jumpState;
    public LandState landState;
    public CrouchIdle crouchIdle;
    public DashState dashState;
    public PlayerDefence defence;
    public WallSliceState wallSliceState;
    public WallJumpState wallJumpState;
    public AttackState attack;
    public Attack1 attack1;
    public PlayerDeathState death;
    public TransitionAttack transition;
    #endregion

    private void Awake()
    {
        //Khoi tao Component
        anim = GetComponent<Animator>();
        _rb2d= GetComponent<Rigidbody2D>();
        input= GetComponent<PlayerInput>();
        collider = GetComponent<BoxCollider2D>();
        ghost= GetComponent<Ghost>();

        //Khoi tao StateMachine
        stateMachine =new PlayerStateMachine();

        //Khoi tao Player State
        idleState=new IdleState(this,stateMachine,data,"Idle");
        moveState = new MoveState(this, stateMachine, data, "Move");
        airState = new PlayerAirState(this, stateMachine, data, "Jump");
        jumpState = new JumpState(this, stateMachine, data, "Jump");
        landState = new LandState(this, stateMachine, data, "Land");
        crouchIdle = new CrouchIdle(this, stateMachine, data, "Crouch");
        dashState = new DashState(this, stateMachine, data, "Dash");
        wallSliceState = new WallSliceState(this, stateMachine, data, "WallSlice");
        wallJumpState = new WallJumpState(this, stateMachine, data, "Jump");
        attack = new AttackState(this, stateMachine, data, "Attack");
        attack1 = new Attack1(this, stateMachine, data, "Attack1");
        death = new PlayerDeathState(this, stateMachine, data, "Die");
        defence = new PlayerDefence(this, stateMachine, data, "Defence");
        transition = new TransitionAttack(this, stateMachine, data, "Trasition");
        hurt = new HurtState(this, stateMachine, data, "Hurt");
    }

    void Start()
    {
        slideDust.Stop();
        stateMachine.Initialize(idleState);
        hp = GetComponent<DamgeReciver>();
        heathBar.maxValue=hp.hpMax;
        curHeath = hp.hpMax;
        heathBar.minValue = 0;
        defBar.maxValue = hp.defence;
        defBar.minValue = 0;
    }

    
    void Update()
    {
        curVerlocity=_rb2d.velocity;
        stateMachine.CurrentState.LogicUpdate();
        heathBar.value = curHeath;
        defBar.value= hp.def;

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

    
    public bool GroundCheck()
    {
        return Physics2D.Raycast(groundCheck.position + data._groundRaycastOffset, Vector2.down, data.groundRadius, data.groundMask) ||
                    Physics2D.Raycast(groundCheck.position - data._groundRaycastOffset, Vector2.down, data.groundRadius, data.groundMask);

    }

    public bool WallFrontCheck()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.left, data.wallDistance, data.groundMask);
    }

    public bool WallCheckBack()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right, data.wallDistance, data.groundMask);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        //Ground Check
        Gizmos.DrawLine(groundCheck.position + data._groundRaycastOffset, groundCheck.position + data._groundRaycastOffset + Vector3.down * data.groundRadius);
        Gizmos.DrawLine(groundCheck.position - data._groundRaycastOffset, groundCheck.position - data._groundRaycastOffset + Vector3.down * data.groundRadius);
        //Wall Check
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * data.wallDistance);
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.left * data.wallDistance);
    }
    #endregion
}
