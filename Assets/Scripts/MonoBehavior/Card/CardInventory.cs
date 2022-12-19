using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory : MonoBehaviour
{
    #region Singleton
    public static CardInventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnChangeCard();
    public OnChangeCard onChangeCard;


    public List<Card>cards = new List<Card>();

    public int CardSlotCnt;
    void Start()
    {
        CardSlotCnt = 2;
    }

    public bool AddCard(Card _card)
    {
        if (cards.Count < CardSlotCnt)
        {
            cards.Add(_card);
            if (onChangeCard != null)
            {
                onChangeCard.Invoke();
            }
            return true;
        }
        return false;
    }

    public void RemoveCard(int _index)
    {
       cards.RemoveAt(_index); 
       onChangeCard.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.CompareTag("FieldCard"))
        {
            print("접촉");
            FieldCard fieldcards = collsion.GetComponent<FieldCard>();
            if (AddCard(fieldcards.GetCard()))
            {
                fieldcards.DestroyCard();
            }
        }
    }

    public void DrawCard()
    {

    }

}