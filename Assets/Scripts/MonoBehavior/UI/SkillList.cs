using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillType
{
    StackSkill,
    NormalSkill,
    RuinSkill
}

public class SkillList : MonoBehaviour
{
    Ammo ammo;
    Weapon weapon;

    public void start()
    {
        weapon = GetComponent<Weapon>();
    }


    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){weapon.FireAmmo();}
        if(Input.GetKeyDown(KeyCode.W)){Skill2();}
        if(Input.GetKeyDown(KeyCode.E)){Skill3();}
        if(Input.GetKeyDown(KeyCode.R)){Skill1();}

    }

    public void Skill1()
    {
        weapon.FireAmmo();
        print("발동");
    }
    
    public void Skill2()
    {
        weapon.FireAmmo();
        print("발동");
    }

    public void Skill3()
    {
        weapon.FireAmmoRight();
        
    }

    public void Skill1Levelup()
    {
        ammo.damageInflicted += 10;
        print("1");
    }
    
    public void Skill2Levelup()
    {
        ammo.damageInflicted += 10;
        print("2");
    }

    public void Skill3Levelup()
    {
        ammo.damageInflicted += 10;
        print("3");
    }
}
