using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public HitPoints HP;
    [HideInInspector]
    public Player Character;
    public Image HPMeterImage;
    public TextMeshProUGUI HPText;
    float maxHP;
    void Start()
    {
        maxHP = Character.maxHP;
    }


    void Update()
    {
        if(Character != null)
        {
            HPMeterImage.fillAmount = HP.hpValue / maxHP;
            HPText.text = "HP:" + (HPMeterImage.fillAmount * maxHP);
        }
    }
}