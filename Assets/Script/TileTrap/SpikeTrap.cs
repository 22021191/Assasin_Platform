using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private Transform takeDamagePoint;
    [SerializeField] private Vector2 sizeTrap;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float coolDownTimer;
    [SerializeField] private int damge;
    private float startTime;
    private DamgeSender sender;
    void Start()
    {
        sender = new DamgeSender(damge);
        takeDamagePoint = transform;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        RaycastHit2D[] hit = Physics2D.BoxCastAll(takeDamagePoint.position, sizeTrap, 0, transform.right, 0, playerMask);
        foreach (RaycastHit2D col in hit)
        {
            if (col && Time.time >= startTime + coolDownTimer)
            {
                startTime = Time.time;
                sender.Send(col.transform);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, sizeTrap);
    }
}