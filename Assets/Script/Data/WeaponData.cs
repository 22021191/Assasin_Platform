using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon Data/Base Data")]
public class WeaponData :ScriptableObject
{
    public int amountOfAttacks;
    public float movementSpeed;
    public float attackSpeed;
    public float attackDistance;
}
