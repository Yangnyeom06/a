using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Card
{
    public string cardName;
    public Sprite cardImage;

    public bool Use()
    {
        return false;
    }
}