using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/Base Data")]
public class Data : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;
}
