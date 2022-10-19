using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownUI : MonoBehaviour
{
    public UnityEngine.UI.Image fill;
    private float maxCooldown = 5f;
    private float currentCooldown = 5f;

    public void SetMaxCooldown(in float value)
    {
        maxCooldown = value;
        UpdateFiilAmount();
    }

    public void SetCurrentCooldown(in float value)
    {
        currentCooldown = value;
        UpdateFiilAmount();
    }

    private void UpdateFiilAmount()
    {
        fill.fillAmount = currentCooldown / maxCooldown;
    }

    // Test
    private void Update()
    {
        SetCurrentCooldown(currentCooldown - Time.deltaTime);

        // Loop
        if (currentCooldown < 0f)
            currentCooldown = maxCooldown;
    }
}