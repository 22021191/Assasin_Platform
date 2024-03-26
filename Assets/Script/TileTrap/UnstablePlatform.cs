using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnstablePlatform : Traps
{
    public float triggerDelay;
    public float selfDestroyDelay;

    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") return;
        _animator.SetBool("Unstable", true);
    }

    protected override void Trigger()
    {
        base.Trigger();
    }


}