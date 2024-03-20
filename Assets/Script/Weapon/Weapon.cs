using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected Animator effect;
    [SerializeField] private LayerMask Enemy;
    [SerializeField] private DamgeSender Damge;
    public string weaponType;

    public void Start()
    {
        Damge =new DamgeSender(weaponData.amountOfAttacks);
    }

    public void EnterWeapon()
    {
        this.gameObject.SetActive(true);
        Attack();
    }

    public void ExitWeapon()
    {
        this.gameObject.SetActive(false);
        //effect.SetBool("Attack", false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, weaponData.attackDistance);
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, weaponData.attackDistance, Enemy);
        if(hitEnemies.Length == 0)
        {
            return;
        }
        //effect.SetBool("Attack", true);
        foreach (Collider2D enemy in hitEnemies)
        {
            Damge.Send(enemy.transform);
            Debug.Log(weaponData.amountOfAttacks);
        }
    }
}
