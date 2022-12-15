using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    public Card card;
    public Image cardIcon;

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
}