using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    // 수정한 부분 <------
    public int damageStrength;
    Coroutine damageCoroutine;
    // ------>
    float HP;
    public GameObject prefabToSpawn1;
    public GameObject prefabToSpawn2;

    private void OnEnable()
    {
        ResetCharacter();
    }

    public override IEnumerator DamageCharacter(float damage, float interval)
    {
        
        while (true)
        {
            StartCoroutine(FlickerCharacter());
            HP = HP - damage;
            GameObject.Find("CardSkillSlotBack(Clone)").GetComponent<GaugeBar>().GaugeCharge(damage);


            if (HP <= float.Epsilon)
            {
                KillCharacter();
                GameObject item = SpawnObject();
                break;
            }


            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    public override void ResetCharacter()
    {
        HP = StartingHP;
    }


    // 수정한 부분 <-----------
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();


            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength, 1.0f));
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
    public GameObject SpawnObject()
    {
        if(prefabToSpawn1 != null)
        {
            return Instantiate(prefabToSpawn1,transform.position, Quaternion.identity);
        }
        if(prefabToSpawn2 != null)
        {
            return Instantiate(prefabToSpawn2,transform.position, Quaternion.identity);
        }
        return null;
    }
    // ------------>
}