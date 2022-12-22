using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    public int slotnum;
    public Card card;
    public Image cardIcon;
    CardInventoryUI cardInvenUI;


    
    public void UpdateCardSlotUI()
    {
        cardIcon.sprite = card.cardImage;
        cardIcon.gameObject.SetActive(true);
    }

    public void RemoveSlot()
    {
        card = null;
        cardIcon.gameObject.SetActive(false);
    }

    public void CardUse()
    {
        bool isUse = card.Use();
    }
}