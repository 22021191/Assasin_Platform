using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FallingTrap : Traps
{
    public float destroyDelay;

    private bool _isTriggered;
    private Rigidbody2D _rigidbody;
    

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
        
        _isTriggered = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player")
            return;
        Fall();
        if (!_isTriggered)
        {
            StartCoroutine(FadeCoroutine());
        }
        trigger();
       
    }

    public override void trigger()
    {
        _isTriggered = true;
    }

    public void Fall()
    {
        _rigidbody.gravityScale = 1;
    }

    private IEnumerator FadeCoroutine()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }


}