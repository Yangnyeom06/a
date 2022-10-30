using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : Character
{
    public HitPoints HP;
    public HitPoints Exp;
    public Inventory inventoryPrefab;
    Inventory inventory;

    public HealthBar healthBarPrefab;
    HealthBar healthBar;
    public ExpBar expBarPrefab;
    ExpBar expBar;
    public SkillChoices SkillSetPrefab;
    SkillChoices skillset;
    public static bool GameIsPaused = false;


    //RPGGameManager rpgGameManager;

    public int playerLevel = 1;

    public void Start()
    {
        inventory = Instantiate(inventoryPrefab);
    }

    /*void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }
*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {

                bool shouldDisappear = false;

                print("Hit: " + hitObject.objectName);

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        shouldDisappear = AdjustExp(hitObject.quantity);
                        break;
                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHP(hitObject.quantity);
                        break;
                    default:
                        break;

                }
                if (shouldDisappear)
                {
                    Destroy(collision.gameObject);
                }

            }
        }
    }
    public bool AdjustHP(int amount)
    {
        if (HP.hpValue < maxHP)
        {
            HP.hpValue += amount;
            //print("Adjusted HP by: " + amount + ". New hpValue: " + HP.hpValue);

            return true;
        }
        return false;
    }

    public bool AdjustExp(int amount)
    {
        if (Exp.expValue < maxExp)
        {
            Exp.expValue += amount;
            print("Adjusted Exp by: " + amount + ". New expValue: " + Exp.expValue);
            if (Exp.expValue >= maxExp)
                    {
                        Exp.expValue = 0;
                        expBar.maxExp += 50;
                        maxExp += 50;
                        playerLevel += 1;
                        //LevelUp();
                        GameObject.Find("SkillManager").GetComponent<SkillManager>().LevelUp();
                        //expBar.Update();
                        print("player Level: " + playerLevel);
                        return true;
                    }
            return true;
        }
        return false;
    }


    // 수정한 부분 <-------
    private void OnEnable()
    {
        ResetCharacter();
    }

    public override void ResetCharacter()
    {
        healthBar = Instantiate(healthBarPrefab);
        HP.hpValue = StartingHP;
        healthBar.Character = this;
        expBar = Instantiate(expBarPrefab);
        Exp.expValue = minExp;
        expBar.Character = this;
    }


    public override IEnumerator DamageCharacter(float damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerCharacter());
            HP.hpValue = HP.hpValue - damage;

            if(HP.hpValue <= float.Epsilon)
            {
                KillCharacter();
                break;
            }
            if(interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }



    public override void KillCharacter()
    {
        base.KillCharacter();

        Destroy(healthBar.gameObject);
        Destroy(expBar.gameObject);
    }

    // -------->
}