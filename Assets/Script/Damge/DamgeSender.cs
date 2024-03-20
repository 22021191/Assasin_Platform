using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeSender 
{
    private int damge;

    public DamgeSender(int damge)
    {
        this.damge = damge;
    }

    public virtual void Send(Transform Obj)
    {
        DamgeReciver damgereciver;
        damgereciver = Obj.GetComponentInChildren<DamgeReciver>();
        if (damgereciver == null) return;
        this.Send(damgereciver);
    }
    public virtual void Send(DamgeReciver reciver)
    {
        reciver.Deduct(this.damge);

    }
}
