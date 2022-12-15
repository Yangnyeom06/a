using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardList : MonoBehaviour
{
    GaugeBar Gaugebar;
    public static CardList cardList;

    private void Awake()
    {
        cardList = this;
    }
    public List<Card>cardlist = new List<Card>();
    
    public GameObject fieldCardPrefab;
    //public GameObject cardSlotPos;
    public Vector3[] pos;

    private void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject card = Instantiate(fieldCardPrefab, pos[i], Quaternion.identity);
            card.GetComponent<FieldCard>().SetCard(cardlist[Random.Range(0, 12)]);
        }
    }
}
