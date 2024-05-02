using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Vector2 size;
    [SerializeField] private float coolDown;
    [SerializeField] private LayerMask player;
    [SerializeField] private int damge;
    private bool isTakeDamge;
    private DamgeSender sender;
    private float endTime = 0;

    private void StartAnimation()
    {
        isTakeDamge = true;
    }
    private void FinishAnimation()
    {
        isTakeDamge=false;
    }

    private void Start()
    {
        sender = new DamgeSender(damge);
    }

    private void Update()
    {
        if (!isTakeDamge) { return; }
        if (endTime + coolDown < Time.time)
        {
            TakeDamge();
        }
    }

    private void TakeDamge()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, size, 90, player);
        if (hit)
        {
            endTime = Time.time;
            sender.Send(hit.transform);
        }
    }

}
