using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public HitPoints Exp;
    [HideInInspector]
    public Player Character;
    public Image ExpMeterImage;
    public float maxExp;
    float minExp;
    void Start()
    {
        maxExp = Character.maxExp;
        minExp = Character.minExp;
    }


    public void Update()
    {
        if(Character != null)
        {
            ExpMeterImage.fillAmount = Exp.expValue / maxExp;
        }
    }
}