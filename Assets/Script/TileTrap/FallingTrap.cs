using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FallingTrap : Traps
{
    [Header("Time")]
    [SerializeField] private float _disableDelay;
    [SerializeField] private Rigidbody2D _rb;

    private bool _hasBeenStepOn=false;
    private bool _allowDisable;
    private BoxCollider2D _boxCollider2D;

    protected override void Awake()
    {
        base.Awake();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }


    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasBeenStepOn && _allowDisable)
        {
            _boxCollider2D.enabled = false;
            _rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_hasBeenStepOn)
        {
            _hasBeenStepOn = true;
            StartCoroutine(Disable());
        }
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(_disableDelay);

        _allowDisable = true;
        //_anim.SetTrigger("Off");
        gameObject.layer = LayerMask.NameToLayer("Decoration");
        _rb.bodyType= RigidbodyType2D.Dynamic;

        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}