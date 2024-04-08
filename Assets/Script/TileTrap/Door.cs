using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform nextZoomPos;
    [SerializeField] private Animator transitionAnim;
    bool isTransition=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isTransition)
            {
                StartCoroutine(TransitionScene(collision));
            }
        }
    }
    IEnumerator TransitionScene(Collider2D player)
    {
        transitionAnim.SetBool("Start", true);
        transitionAnim.SetBool("End",false);
        isTransition = true;
        yield return new WaitForSeconds(1.5f);
        player.transform.position=nextZoomPos.position;
        transitionAnim.SetBool("Start", false);
        transitionAnim.SetBool("End", true);

    }
}
