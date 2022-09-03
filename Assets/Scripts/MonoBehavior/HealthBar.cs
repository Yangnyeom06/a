using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HitPoints HP;
    [HideInInspector]
    public Player Character;
    public Image HPMeterImage;
    public Text HPText;
    float maxHP;
    void Start()
    {
        maxHP = Character.maxHP;
    }


    void Update()
    {
        if(Character != null)
        {
            HPMeterImage.fillAmount = HP.value / maxHP;
            HPText.text = "HP:" + (HPMeterImage.fillAmount * 100);
        }
    }
}