using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float sizeTrap;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float coolDownTimer;
    [SerializeField] private int damge;
    private float startTime;
    private DamgeSender sender;
    private void DisableObj()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {
        sender=new DamgeSender(damge);
    }
    private void Update()
    {
        TakeDamage();   
    }
    private void TakeDamage()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position,sizeTrap, playerMask);
        if (hit && Time.time >= startTime + coolDownTimer)
        {
            ResetTime();
            sender.Send(hit.transform);
        }
    }
    public void ResetTime()
    {
        startTime=Time.time;
    }
}
