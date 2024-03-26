using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : Enemy
{
    public PlantIdleState idleState { get; private set; }
    public PlantAttackState attackState { get; private set; }
    public PlantStunState stunState { get; private set; }

    [Header("Bullet")]
    [SerializeField] private GameObject bullet;

    [Header("Value other")]
    [SerializeField] private float _disableDelay;

    public override void Awake()
    {
        base.Awake();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Start()
    {
        base.Start();
        idleState = new PlantIdleState(this, stateMachine, "Idle", data);
        attackState = new PlantAttackState(this, stateMachine, "Attack", data,transform);
        stunState = new PlantStunState(this, stateMachine, "Hurt", data);
    }

    public override void Update()
    {
        if (reciver.hp == 0)
        {
            StartCoroutine(Disable());
            return;
        }
        base.Update();
    }

    public void Shoot()
    {
        GameObject bulletSpawn= Instantiate(bullet, transform.position, Quaternion.identity);
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(_disableDelay);

        gameObject.layer = LayerMask.NameToLayer("Decoration");
        rb2d.bodyType = RigidbodyType2D.Dynamic;

        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
