using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSwitchCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _prevCamera;
    [SerializeField] CinemachineVirtualCamera _camNeedToSwitch;
    private CinemachineVirtualCamera curCam;


    private void Start()
    {
        curCam = _prevCamera;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerInput>().enabled = false;
            collision.GetComponent<Player>().NextRoom();
                        
            Vector3 pos= this.transform.position;
            pos.x += 1;
            GameManager.Instance.pos = pos;

            StartCoroutine(TransitionCamera(collision));
        }
        
    }

    IEnumerator TransitionCamera(Collider2D player)
    {

        UiManager.Instance.transitionAnim.gameObject.SetActive(true);
        UiManager.Instance.transitionAnim.SetBool("Start", true);
        UiManager.Instance.transitionAnim.SetBool("End", false);
        yield return new WaitForSeconds(1.5f);
        
        yield return new WaitForSeconds(1f);

        if (curCam==_prevCamera)
        {
            CameraController.Instance.SwitchingCamera(_camNeedToSwitch);
            curCam = _camNeedToSwitch;

        }
        else
        {
            CameraController.Instance.SwitchingCamera(_prevCamera);
            curCam = _prevCamera;

        }
        curCam.Follow = player.transform;
        yield return new WaitForSeconds(1f);
        UiManager.Instance.transitionAnim.SetBool("Start", false);
        UiManager.Instance.transitionAnim.SetBool("End", true);
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerInput>().enabled = true;
        yield return new WaitForSeconds(1f);
        UiManager.Instance.transitionAnim.gameObject.SetActive(false);
        

    }

}