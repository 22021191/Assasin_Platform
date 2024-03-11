using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("StateMachine")]
    public PlayerStateMachine stateMachine;

    [Header("Component")]
    [SerializeField] private Rigidbody2D _rb2d;
    public Animator anim { get;private set; }

    [Header("PlayerData")]
    [SerializeField] private Data data;

    [Header("Player State")]
    [SerializeField] private IdleState idleState;

    private void Awake()
    {
        //Khoi tao Component
        anim = GetComponent<Animator>();
        _rb2d= GetComponent<Rigidbody2D>();

        //Khoi tao StateMachine
        stateMachine=new PlayerStateMachine();

        //Khoi tao Player State
        idleState=new IdleState(this,stateMachine,data,"Idle");
    }

    void Start()
    {
        stateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }
}
