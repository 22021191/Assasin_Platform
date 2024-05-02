using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    private bool playerDetected;
    [SerializeField] private bool isBoss;
    [SerializeField] private BossManager bossManager;
    [SerializeField] private Transform nextZoomPos;
    [SerializeField] private CinemachineVirtualCamera nextCam;
    [SerializeField] private Animator transitionAnim;
    [SerializeField] private GameObject col1, col2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {       
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (dialogueScript.endDialogue)
        {
            dialogueScript.endDialogue = false;
            if (isBoss)
            {
                gameObject.layer = LayerMask.NameToLayer("Enemy");
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                bossManager.enabled = true;
                GameManager.Instance.curBoss = bossManager;
                bossManager.EnableHeath();
                col1.SetActive(true);
                col2.SetActive(true);
                this.enabled = false;
               
            }
            else
            {
                StartCoroutine(TransitionScene(collision));
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
            dialogueScript.EndDialogue();
        }
    }
    private void Start()
    {
        if(isBoss)
        {
            bossManager.enabled=false;
        }
    }
    private void Update()
    {
        if (dialogueScript.endDialogue)
        {
            return;
        }
        else if (playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }
    }


    IEnumerator TransitionScene(Collider2D player)
    {
        transitionAnim.SetBool("Start", true);
        transitionAnim.SetBool("End", false);
        yield return new WaitForSeconds(1.5f);
        player.transform.position=nextZoomPos.position;
        nextCam.Follow = player.transform;
        CameraController.Instance.SwitchingCamera(nextCam);
        yield return new WaitForSeconds(1f);
        transitionAnim.SetBool("Start", false);
        transitionAnim.SetBool("End", true);

    }

}
