using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSwitchCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _prevCamera;
    [SerializeField] CinemachineVirtualCamera _camNeedToSwitch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int directon = collision.gameObject.GetComponent<Player>().facingRight;
            if (directon > 0)
            {
                CameraController.Instance.SwitchingCamera(_camNeedToSwitch);
            }
            else
            {
                CameraController.Instance.SwitchingCamera(_prevCamera);
            }
        }
        
    }
    
}