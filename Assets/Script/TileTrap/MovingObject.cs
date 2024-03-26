using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private GameObject[] WayPoints;
    [SerializeField] private int currentPoint = 0;
    [SerializeField] private float speed = 2f;


    protected virtual void Start()
    {
        if (WayPoints.Length <= 0)
        {
            return;
        }
        transform.position = WayPoints[currentPoint].transform.position;
        if (currentPoint < WayPoints.Length - 1 && currentPoint != 0)
        {
            currentPoint++;
        }
        else
        {
            currentPoint = 0;
        }
    }

    protected virtual void Update()
    {
        if (Vector2.Distance(WayPoints[currentPoint].transform.position, transform.position) < 0.1)
        {
            currentPoint++;
            if (currentPoint >= WayPoints.Length)
            {
                currentPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,
            WayPoints[currentPoint].transform.position,
            Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
