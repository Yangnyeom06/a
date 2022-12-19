using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventoryUI : MonoBehaviour
{
    CardInventory cardInven;
    public Card card;

    public GameObject cardInventoryPanel;

    public CardSlot[] cardSlots;
    public Transform slotHolder;

    private void Start()
    {        
        cardInven = CardInventory.instance;
        cardSlots = slotHolder.GetComponentsInChildren<CardSlot>();
        cardInven.onChangeCard += RedrawSlotUI;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) & cardSlots[0] != null)
        {
            cardSlots[0].RemoveSlot();
            if (cardInven.cards[0] != null)
            {
                cardInven.cards.RemoveAt(0);
            }
            
        }
        else if (Input.GetKey(KeyCode.X) & cardSlots[1] != null)
        {
            cardSlots[1].RemoveSlot();
            if (cardInven.cards[1] != null)
            {
                cardInven.cards.RemoveAt(1);
            }
        }
        else
        {
            return;
        }

    }

    void RedrawSlotUI()
    {
        print("작동확인");
        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].RemoveSlot();
        }
        for (int i = 0; i < cardInven.cards.Count; i++)
        {
            cardSlots[i].card = cardInven.cards[i];
            cardSlots[i].UpdateCardSlotUI();
        }
    }
}