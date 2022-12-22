using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="CardEft/Consumable/Star")]
public class Star : CardEffect
{
    public GameObject heart;
    public Player player;
    Transform transform;
    public void Awake()
    {
        
    }

    public override bool ExecuteRole()
    {
        transform = player.GetComponent<Transform>();
        Debug.Log(transform.gameObject);
        Debug.Log(transform.gameObject.transform.position);
        Instantiate(heart, transform.transform.position, Quaternion.identity);
        return true;
    }
}