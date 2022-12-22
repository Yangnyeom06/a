using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Card
{
    //public GameObject cardPrefab;
    public string cardName;
    public Sprite cardImage;
    public List<CardEffect> efts;

    public bool Use()
    {
        //bool isUsed = false;
        foreach (CardEffect eft in efts)
        {
            eft.ExecuteRole();
        }
        //isUsed = true;
        return true;
    }
}