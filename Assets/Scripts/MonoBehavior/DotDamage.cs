using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDamage : MonoBehaviour
{
    public float damageInflicted;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision is BoxCollider2D)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            StartCoroutine(enemy.DamageCharacter(damageInflicted, 0.0f));

            //gameObject.SetActive(false);
        }
    }
}
