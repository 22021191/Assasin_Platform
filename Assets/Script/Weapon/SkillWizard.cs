using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWizard : MonoBehaviour
{
    [SerializeField] private BulletData data;
    [SerializeField] private Animator anim;
    private float startTime;
    private DamgeSender sender;
    private bool endDamge;
    private bool finish;
    public Vector2 limit;


    public void Start()
    {
        anim = GetComponent<Animator>();
        sender = new DamgeSender(data.damge);
        
        finish = false;
        StartCoroutine(ExecuteAfterDelay(5));
    }

    public void Update()
    {
        TakeDamgePlayer();
        
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, data.sizeAttack);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(transform.position, data.size, data.groundMask);
    }

    private void TakeDamgePlayer()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, data.sizeAttack,90, data.playerMask);
        if (hit && !endDamge)
        {
            sender.Send(hit.transform);
            
            endDamge = true;
        }
    }
    public void ResetTime()
    {
        startTime = Time.time;
    }

    IEnumerator ExecuteAfterDelay(int turn)
    {
        while (turn > 0)
        {
            if (finish)
            {
                finish = false;
                turn--;
            }

            yield return null;
        }
        Destroy(gameObject);
        
    }
    public void FinishBullet()
    {
        finish = true;
        float x = Random.RandomRange(limit.x, limit.y);
        transform.position = new Vector3(x, transform.position.y, 0);
        
    }

    public void EndSendamge()
    {
        endDamge = true;
    }
    public void StartDamge()
    {
        endDamge = false;
    }
}
