using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("PlayerData")]
    [SerializeField] private Data data;

    #region Value
    [Header("Component")]
    [SerializeField] private Rigidbody2D _rb2d;

    [Header("Variable")]
    private Vector2 workPlace;
    private Vector2 curVerlocity;
    [SerializeField] private int facingRight;
    public PlayerInput input;
    public Animator anim { get;private set; }
    #endregion

    #region State Value
    [Header("StateMachine")]
    public PlayerStateMachine stateMachine;

    [Header("Player State")]
    public IdleState idleState;
    public MoveState moveState;
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
        workPlace.Set(speed, curVerlocity.y);
        _rb2d.velocity = workPlace;
        curVerlocity = workPlace;
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
    #endregion

    #region Other Functions
    private void Flip()
    {
        facingRight *= -1;
        transform.Rotate(0, 180, 0);
    }
    #endregion
}
