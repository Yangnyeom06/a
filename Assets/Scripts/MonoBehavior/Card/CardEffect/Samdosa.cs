using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CardEft/Consumable/Samdosa")]
public class Samdosa : CardEffect
{
    public Weapon weapon;
  
    public override bool ExecuteRole()
    {
        Debug.Log('a');
        weapon.samdusa = true;
        return true;
    }
}