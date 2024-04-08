using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/Base Data")]
public class Data : ScriptableObject
{
    [Header("Move State")]
    public float maxSpeed = 12f;
    public float acceleration = 30f;
    public float deceleration = 180f;
    public float _groundLinearDrag = 7f;

    [Header("Jump State")]
    public float jumpForce = 15f;

    [Header("Air State")]
    public float airLinearDrag = 2.5f;
    public float fallMultiplier = 5f;
    public float jumpMultiplier = 3f;
    public float coyoteTime = 0.2f;

    [Header("Collider Check")]
    public float groundRadius;
    public float wallDistance;
    public LayerMask groundMask;

    [Header("Wall Slice")]
    public float sliceSpeed=3f;

    [Header("Wall Climb")]
    public float climdSpeed = 3f;

    [Header("Wall Jump")]
    public float wallJumpTime;
    public float wallJumpVelocity;
    public Vector2 wallAngle=new Vector2(1,2);

    [Header("Crouch")]
    public float standColliderHeight = 2f;
    public float crouchColliderHeight=0.8f;

    [Header("Dash")]
    public float dashSpeed = 15f;
    public float dashLength = .3f;
    public float dashCounter = .5f;
    

    [Header("Ledge Climb")]
    public float ledgeDistance;
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("Attack")]
    public int comboCount;
}
