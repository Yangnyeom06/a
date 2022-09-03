using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : Character
{
    //수정한 부분 <------
    public HitPoints HP;
    // ------>
    //public Inventory inventoryPrefab;
    //Inventory inventory;


    public HealthBar healthBarPrefab;
    HealthBar healthBar;

    float speed = 10;

/* 삭제할 것입니다.
    public void Start()
    {

        inventory = Instantiate(inventoryPrefab);
        healthBar = Instantiate(healthBarPrefab);
        HP.value = StartingHP;
        healthBar.Character = this;
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


                        //shouldDisappear = inventory.AddItem(hitObject);
                       

                        break;
                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHP(hitObject.quantity);
                        break;
                    default:
                        break;

                }
                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }

            }
        }
    }
    public bool AdjustHP(int amount)
    {
        if (HP.value < maxHP)
        {
            HP.value += amount;
            print("Adjusted HP by: " + amount + ". New Value: " + HP.value);

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
        //inventory = Instantiate(inventoryPrefab);
        healthBar = Instantiate(healthBarPrefab);
        HP.value = StartingHP;
        healthBar.Character = this;
    }

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            HP.value = HP.value - damage;

            if(HP.value <= float.Epsilon)
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
        //Destroy(inventory.gameObject);
    }

    // -------->
}