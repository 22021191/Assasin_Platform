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
    public bool dashInput;
    public float dashInputStartTime;
    public float inputHoldTime;

    [Header("Wall")]
    public bool grabInput;

    [Header("Jump")]
    public bool jumpInput;

    [Header("Attack")]
    public bool attackInput;
    public float attackInputStartTime;
    public bool canNextCombo;
    public float timeNextCombo;

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
        if (Input.GetKeyDown(KeyCode.L))
        {
            dashInput = true;
            dashInputStartTime = Time.time;
        }
        
    }

    public bool DashStop()
    {
        return Input.GetKeyUp(KeyCode.L);
    }

    public void GrabInput()
    {
        grabInput = Input.GetKey(KeyCode.O);
    }
    public void UseDashInput() => dashInput = false;

    private void CheckDashInputHoldTime()
    {
        if (Time.time >= dashInputStartTime + inputHoldTime)
        {
            dashInput = false;
        }
    }

    public Vector2 DashDirectionInput(float facing)
    {
        if (inputX == inputY && inputY == 0)
        {
            return Vector2.right * facing;
        }
        return new Vector2(inputX,inputY);
    }

    public void AttackInput()
    {
        attackInput=Input.GetKeyDown(KeyCode.J);
        canNextCombo = Time.time > attackInputStartTime + timeNextCombo;
    }

    private void Update()
    {
        MoveInput();
        GrabInput();
        JumpInput();
        DashInput();
        AttackInput();
    }
}
