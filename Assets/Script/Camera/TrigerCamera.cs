using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _prevCamera;
    [SerializeField] CinemachineVirtualCamera _camNeedToSwitch;
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
                CameraController.Instance.SwitchingCamera(_camNeedToSwitch);
            _prevCamera.Follow = collision.transform;
        }

    }
}
