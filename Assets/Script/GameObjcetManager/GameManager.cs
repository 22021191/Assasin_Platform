using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public Player player;
    [SerializeField] public Vector3 pos;
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
        if (player.hp.hp == 0||won)
        {
            UiManager.Instance.EndGame();
        }
    }

    public void ResetData()
    {
        player.ResetData(pos);
        curBoss.ResetData();
    }

    public void Restart()
    {
        StartCoroutine(UiManager.Instance.Transition(pos));
        ResetData();  
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
