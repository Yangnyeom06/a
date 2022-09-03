using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    //public HitPoints HP; 삭제할 예정입니다.
    
    public float maxHP;
    public float StartingHP;
		//수정한 부분 <------
    public virtual void KillCharacter()
    {
        Destroy(gameObject);
    }

    public abstract void ResetCharacter();
    public abstract IEnumerator DamageCharacter(int damage, float interval);
    
       	// ----->
}