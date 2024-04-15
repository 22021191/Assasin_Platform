using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform nextZoomPos;
    [SerializeField] private Animator transitionAnim;
    [SerializeField] private CinemachineVirtualCamera nextCam;
    [SerializeField] private PlayableDirector playable;
    
    bool isTransition=false;


    private void Start()
    {
        playable.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().SetVelocityZero();

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
        CameraController.Instance.SwitchingCamera(nextCam);

        yield return new WaitForSeconds(1f);
        transitionAnim.SetBool("Start", false);
        transitionAnim.SetBool("End", true);
        playable.Play();
        
    }
}
