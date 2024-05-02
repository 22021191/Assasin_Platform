using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public Player player;
    [SerializeField] public Transform pos;
    [SerializeField] public BossManager curBoss;

    public bool won;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    

    private void Update()
    {
        if(player==null) { return; }
        if (player.hp.hp == 0)
        {
            won = false;
            UiManager.Instance.EndGame();
        }
    }

    private void ResetData()
    {
        player.ResetData(pos);
        curBoss.ResetData();
    }

    public void Restart()
    {
        StartCoroutine(UiManager.Instance.Transition(pos.position));
        ResetData();  
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
