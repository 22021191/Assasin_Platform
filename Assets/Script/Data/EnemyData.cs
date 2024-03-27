using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemyData:ScriptableObject 
{
    [Header("Damge")]
    public int maxHealth = 30;
    public float damageHopSpeed = 3f;
    public float damgeAttack;
    public float attackDistance;

    [Header("Collider")]
    public float wallCheckDistance = 0.2f;
    public float groundCheckRadius = 0.3f;
    public LayerMask _GroundMask;
    public LayerMask _PlayerMask;

    public float minIdleTime;
    public float maxIdleTime;

    public float speed;
    public float maxLookPlayerDistance;
    public float maxDistanceAttack;

}
