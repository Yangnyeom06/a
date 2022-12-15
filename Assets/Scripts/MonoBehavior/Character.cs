using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    
    public float maxHP;
    public float StartingHP;
    public float maxExp;
    public float minExp;
    public float minGauge;
    public float maxGauge;
    
    public virtual void KillCharacter()
    {
        Destroy(gameObject);
    }

    public abstract void ResetCharacter();
    public abstract IEnumerator DamageCharacter(float damage, float interval);
    
    public virtual IEnumerator FlickerCharacter()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}