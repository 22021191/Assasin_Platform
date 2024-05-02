using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSwitchCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _prevCamera;
    [SerializeField] CinemachineVirtualCamera _camNeedToSwitch;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerInput>().enabled = false;
            collision.GetComponent<Player>().NextRoom();
            int directon = collision.gameObject.GetComponent<Player>().facingRight;
            GameManager.Instance.pos=this.transform;

            StartCoroutine(TransitionCamera(collision, directon));
        }
        
    }

    IEnumerator TransitionCamera(Collider2D player,int direction)
    {

        UiManager.Instance.transitionAnim.gameObject.SetActive(true);
        UiManager.Instance.transitionAnim.SetBool("Start", true);
        UiManager.Instance.transitionAnim.SetBool("End", false);
        yield return new WaitForSeconds(1.5f);
        
        yield return new WaitForSeconds(1f);

        if (direction > 0)
        {
            CameraController.Instance.SwitchingCamera(_camNeedToSwitch);

        }
        else
        {
            CameraController.Instance.SwitchingCamera(_prevCamera);

        }

        yield return new WaitForSeconds(1f);
        UiManager.Instance.transitionAnim.SetBool("Start", false);
        UiManager.Instance.transitionAnim.SetBool("End", true);
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerInput>().enabled = true;
        yield return new WaitForSeconds(1f);
        UiManager.Instance.transitionAnim.gameObject.SetActive(false);
        

    }

}