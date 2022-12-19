using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Card
{
    public string cardName;
    public Sprite cardImage;
    public List<CardEffect> efts;

    public bool Use()
    {
        bool isUsed = false;
        foreach (CardEffect eft in efts)
        {
            isUsed = eft.ExecuteRole();
        }
        isUsed = true;
        return isUsed;
    }
}