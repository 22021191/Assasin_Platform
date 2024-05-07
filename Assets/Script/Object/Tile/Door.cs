using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform nextZoomPos;
    [SerializeField] private CinemachineVirtualCamera nextCam;
    [SerializeField] private BossManager boss;
    bool isTransition=false;

    private void Start()
    {
        if (boss != null)
        {
            boss.gameObject.SetActive(false);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().NextRoom();
            GameManager.Instance.curBoss = boss;
            GameManager.Instance.pos=transform.position;
            if (!isTransition)
            {
                StartCoroutine(TransitionScene(collision));
            }
        }
    }
    IEnumerator TransitionScene(Collider2D player)
    {

        player.gameObject.GetComponent<PlayerInput>().enabled=false;
        UiManager.Instance.transitionAnim.gameObject.SetActive(true);
        UiManager.Instance.transitionAnim.SetBool("Start", true);
        UiManager.Instance.transitionAnim.SetBool("End", false);
        yield return new WaitForSeconds(1.5f);
        isTransition = true;
        
        yield return new WaitForSeconds(1f);
        player.transform.position=nextZoomPos.position;
        CameraController.Instance.SwitchingCamera(nextCam);

        yield return new WaitForSeconds(1f);
        UiManager.Instance.transitionAnim.SetBool("Start", false);
        UiManager.Instance.transitionAnim.SetBool("End", true);
        yield return new WaitForSeconds(1f);
        nextCam.Follow=player.transform;
        player.GetComponent <PlayerInput>().enabled=true;
        if (boss != null)
        {
            boss.gameObject.SetActive(true);
            boss.EnableHeath();
            boss.enabled = true;
        }
        yield return new WaitForSeconds(1f);
        UiManager.Instance.transitionAnim.gameObject.SetActive(false);
        isTransition = false;

    }
}
