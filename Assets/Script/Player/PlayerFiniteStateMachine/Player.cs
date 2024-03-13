using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("PlayerData")]
    [SerializeField] private Data data;

    #region Value
    [Header("Component")]
    public Rigidbody2D _rb2d;

    [Header("Variable")]
    private Vector2 workSpace;
    private Vector2 curVerlocity;
    [SerializeField] private int facingRight;
    [SerializeField] private string changeAnimName;
    [SerializeField] private GameObject groundCheck;
    public PlayerInput input;
    public Animator anim { get;private set; }
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
    #endregion

    private void Awake()
    {
        //Khoi tao Component
        anim = GetComponent<Animator>();
        _rb2d= GetComponent<Rigidbody2D>();
        input= GetComponent<PlayerInput>();

        //Khoi tao StateMachine
        stateMachine=new PlayerStateMachine();

        //Khoi tao Player State
        idleState=new IdleState(this,stateMachine,data,"Idle");
        moveState = new MoveState(this, stateMachine, data, "Move");
        airState = new PlayerAirState(this, stateMachine, data, "Jump");
        jumpState = new JumpState(this, stateMachine, data, "Jump");
        landState = new LandState(this, stateMachine, data, "Land");
    }

    void Start()
    {
        stateMachine.Initialize(idleState);
    }

    
    void Update()
    {
        curVerlocity=_rb2d.velocity;
        stateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }
    #region Set Function
    public void SetVelocityX(float speed)
    {
        workSpace.Set(speed, curVerlocity.y);
        _rb2d.velocity = workSpace;
        curVerlocity = workSpace;
    }

    public void SetVelocityY(float force)
    {
        workSpace.Set(curVerlocity.x, force);
        _rb2d.velocity = workSpace;
        curVerlocity = _rb2d.velocity;
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
        return Physics2D.OverlapCircle(groundCheck.transform.position, data.groundRadius, data.groundMask);
    }
    #endregion

    #region Other Functions
    private void Flip()
    {
        facingRight *= -1;
        transform.Rotate(0, 180, 0);
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
