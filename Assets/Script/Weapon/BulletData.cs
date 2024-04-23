using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Data/Bullet Data/Base Data")]

public class BulletData : ScriptableObject
{
    public int damge;
    public float speed;
    public float size;
    public float coolDownTimer;
    public LayerMask groundMask;
    public LayerMask playerMask;
    public Vector2 sizeAttack;

}
