using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventoryUI : MonoBehaviour
{
    CardInventory cardInven;

    public GameObject cardInventoryPanel;

    public CardSlot[] cardSlots;

    private void Start()
    {
        cardInven.onChangeCard += RedrawSlotUI;
    }

    void RedrawSlotUI()
    {
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