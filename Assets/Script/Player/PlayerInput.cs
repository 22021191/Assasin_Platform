using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Movement")]
    public Vector2 moveInput;
    public int inputX;
    public int inputY;

    [Header("Dash")]
    public bool dash;
    public float counter;

    [Header("Wall")]
    public bool grabInput;

    [Header("Jump")]
    public bool jumpInput;

    public void MoveInput()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputX = (int)(moveInput * Vector2.right).normalized.x;
        inputY= (int)(moveInput * Vector2.up).normalized.y;
       
    }

    public void JumpInput()
    {
        jumpInput = (Input.GetKeyDown(KeyCode.K) || Input.GetButton("Jump"));
        
    }

    public void DashInput()
    {
        counter-=Time.deltaTime;
        dash = Input.GetKeyDown(KeyCode.L)&&(counter<0);
    }

    public void GrabInput()
    {
        grabInput = Input.GetKey(KeyCode.O);
    }

    private void Update()
    {
        MoveInput();
        GrabInput();
        JumpInput();
        DashInput();
    }
}
