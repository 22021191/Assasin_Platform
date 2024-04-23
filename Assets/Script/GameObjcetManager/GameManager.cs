using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //[SerializeField] public Player player;
    [SerializeField] private Transform pos;
    public bool won;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //player.gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }

    private void ResetData()
    {
     /*   player.hp.hp = player.hp.hpMax;
        player.hp.def = player.hp.defence;
        player.transform.position=pos.position;
    */}

    public void Restart()
    {
        StartCoroutine(UiManager.Instance.Transition(pos.position));
        ResetData();  
    }
}
