using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float coolDown=0.1f;
   
    [SerializeField] private int damge;
    [SerializeField] private bool isTakeDamge;
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
        endTime = 0;
        sender = new DamgeSender(damge);
    }

    private void Update()
    {
        if (isTakeDamge)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled=false;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time > endTime + coolDown && collision.gameObject.tag == "Player")
        {
            endTime = Time.time;
            sender.Send(collision.transform);
        }
    }

   
}
