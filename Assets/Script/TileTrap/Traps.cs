using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Traps : MonoBehaviour
{
    protected Animator _anim;
    protected string _ID;
    protected virtual void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    protected void SetUpObject()
    {

    }
    protected virtual void Trigger()
    {

    }
}