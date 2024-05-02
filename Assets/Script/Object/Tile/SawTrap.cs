using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MovingObject
{
    [SerializeField] private float coolDownTimer;
    [SerializeField] private int damge;
    private float startTime;
    private DamgeSender sender;

    protected override void Start()
    {
        base.Start();
        sender = new DamgeSender(damge);
    }

    protected override void Update()
    {
        base.Update();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        if (collision && Time.time >= startTime + coolDownTimer)
        {
            startTime = Time.time;
            sender.Send(collision.transform);
        }
    }

}
