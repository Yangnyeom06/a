using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    GaugeBar GaugeBar;
    Player player;
    public int damageInflicted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision is BoxCollider2D)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            StartCoroutine(enemy.DamageCharacter(damageInflicted, 0.0f));
            //GameObject.Find("CardSlotSkill(Clone)").GetComponent<GaugeBar>().GaugeCharge(damageInflicted);

        }
    }
}