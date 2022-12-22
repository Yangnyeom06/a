using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventoryUI : MonoBehaviour
{
    CardInventory cardInven;
    public CardSlot cardslot;
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            try
            {
                cardSlots[0].CardUse();
                cardSlots[0].RemoveSlot();
                cardInven.cards.RemoveAt(0);
                RedrawSlotUI();
            }
            catch
            {

            }
        }

        else if (Input.GetKeyDown(KeyCode.X))
        {
            try
            {
                cardSlots[1].CardUse();
                cardSlots[1].RemoveSlot();
                cardInven.cards.RemoveAt(1);
                RedrawSlotUI();
            }
            catch
            {

            }
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