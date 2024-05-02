using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Health,
    Mana
 }
public class Iterm : MonoBehaviour
{
    public ItemType itemType;
    public int value;

    void IncreaseMana(DamgeReciver reciver)
    {
        reciver.def += value;
        if(reciver.def > reciver.defence)
        {
            reciver.def = reciver.defence;
        }
    }

    void IncreaseHealth(DamgeReciver reciver)
    {
        reciver.hp+= value;
        if(reciver.hp>reciver.hpMax)
        {
            reciver.hp = reciver.hpMax;
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && player.collectItem)
        {
            switch (itemType)
            {
                case ItemType.Health:
                    IncreaseHealth(player.hp);
                    player.curHeath = player.hp.hp;
                    break;
                case ItemType.Mana:
                    IncreaseMana(player.hp);
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }

    }
}
