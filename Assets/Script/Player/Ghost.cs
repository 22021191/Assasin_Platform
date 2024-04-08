using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public bool makeGhost;
    [SerializeField] private float timeLife;
    [SerializeField] private GameObject ghost;
    [SerializeField] private float ghostDelay;
    [SerializeField] private Sprite[] ghostSprite;
    private float ghostDelaySecond;
    int index = 0;
    void Start()
    {
        ghostDelaySecond = ghostDelay;
    }

    // Update is called once per frame
    public void MakeGhostRender()
    {
        if (!makeGhost)
        {
            return;
        }
        if (ghostDelaySecond > 0)
        {
            ghostDelaySecond -= Time.deltaTime;
            index = index == 0 ? 1 : 0;
        }
        else
        {
            GameObject curGhost = Instantiate(ghost, transform.position, transform.rotation);
            Sprite curSprite = GetComponent<SpriteRenderer>().sprite;
            curGhost.GetComponent<SpriteRenderer>().sprite = curSprite;
            curGhost.GetComponent<SpriteRenderer>().sprite = ghostSprite[index];
            Destroy(curGhost, timeLife);
            ghostDelaySecond = ghostDelay;
        }
    }
}
