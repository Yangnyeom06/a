using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CardEft/Consumable/Madness")]
public class Madness : CardEffect
{
    Weapon weapon;

    public override bool ExecuteRole()
    {
        weapon.shootDelay = 0.1f;
        return true;
    }
}