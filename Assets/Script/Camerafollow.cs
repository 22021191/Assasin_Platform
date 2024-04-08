using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] private Transform Taget;
    [SerializeField] private Vector3 veclocity = Vector3.zero;
    [SerializeField] private Vector3 Posset;
    [SerializeField] private float smoothTime;
    private Camerafollow Instance;
    public Camerafollow instance { get { return Instance; } }
    public void Awake()
    {
        Taget = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        Vector3 tagetPos=Taget.position+Posset;
        transform.position =Vector3.SmoothDamp(transform.position,tagetPos,ref veclocity,smoothTime);
    }
}
