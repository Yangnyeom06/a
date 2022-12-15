using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldCard : MonoBehaviour
{
    public Card card;
    public SpriteRenderer cardimage;

    public void SetCard(Card _card)
    {
        card.cardName = _card.cardName;
        card.cardImage = _card.cardImage;
        
        cardimage.sprite = _card.cardImage;
    }

    public Card GetCard()
    {
        return card;
    }

    public void DestroyCard()
    {
        Destroy(gameObject);
    }

}
