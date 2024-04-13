using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeReciver : MonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] public int def;
    [SerializeField] public int defence;
    [SerializeField] public int hp = 1;
    [SerializeField] public int hpMax = 2;
    [SerializeField] protected bool isDead = false;
    public bool isDefence=false;

    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public virtual void Reborn(int max)
    {
        this.hpMax= max;
        this.hp= max;
        this.isDead = false;
    }

    public virtual void Add(int add)
    {
        if (this.isDead) return;

        this.hp += add;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int deduct)
    {
        if (this.isDead) return;
        if (isDefence && def > 0)
        {
            this.def-= deduct;
        }
        if(def<0)
        {
            def = 0;
            deduct = def;
        }
        else
        {
            return;
        }
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    public bool IsDead()
    {
        if (hp <= 0)
        {
            if (gameObject.CompareTag("Player")) return this.hp <= 0;
            
            return true;
        }
        return false;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void OnDead()
    {
        //For override
    }
}
