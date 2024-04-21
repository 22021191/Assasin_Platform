using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletData data;
    [SerializeField] private Animator anim;
    private float startTime;
    private DamgeSender sender;
    private bool isExplosion;

    Rigidbody2D rb;

    public void Start()
    {
        anim=GetComponent<Animator>();
        sender = new DamgeSender(data.damge);
        rb=GetComponent<Rigidbody2D>();
        StartCoroutine(ExecuteAfterDelay(2));
    }

    public void Update()
    {
        TakeDamgePlayer();
        int x = transform.rotation.y == 0 ? 1 : -1;
        if(isExplosion)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity=new Vector2 (x,0)*data.speed;
        }
        if (GroundCheck())
        {
            isExplosion = true;
            anim.SetBool("Destroy", true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, data.size);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(transform.position, data.size, data.groundMask);
    }

    private void TakeDamgePlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, data.size, data.playerMask);
        if (hit)
        {
            sender.Send(hit.transform);
            anim.SetBool("Destroy", true);
            isExplosion=true;
        }
    }
    public void ResetTime()
    {
        startTime = Time.time;
    }
    IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        anim.SetBool("Destroy", true);
        isExplosion = true;
    }
    public void OnDestroyBullet()
    {
        Destroy(gameObject);
    }
}
