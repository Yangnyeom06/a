using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeBar : MonoBehaviour
{
    public HitPoints Gauge;
    [HideInInspector]
    public Player Character;
    public Image GaugeMeterImage;
    float maxGauge;
    float minGauge;

    void Start()
    {
        maxGauge = Character.maxGauge;
        minGauge = Character.minGauge;
    }


    public void Update()
    {
        if(Character != null)
        {
            GaugeMeterImage.fillAmount = Gauge.gaugeValue / maxGauge;   
        }
    }
    public void GaugeCharge(float damageInflicted)
    {
        Gauge.gaugeValue += damageInflicted;
        print(Gauge.gaugeValue);
        if (Gauge.gaugeValue >= maxGauge)
        {
            Gauge.gaugeValue = 0;
            GameObject.Find("PlayerObject(Clone)").GetComponent<CardInventory>().DrawCard();

            print("성공");
        }
    }

}