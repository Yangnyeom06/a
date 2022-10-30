using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public SkillChoices SkillSetPrefab;
    SkillChoices skillset;
    public static bool GameIsPaused = false;
    public GameObject SkillChoice1;
    public GameObject SkillChoice2;
    public GameObject SkillChoice3;

    public int SkillCount;
    
    void Start()
    {
        List<int> SkillList = new List<int>();
        for (int i = 0; i < SkillCount; ++i)
        {
            SkillList.Add(i);
        }
        ResetSkillChoices();
    }
    

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
                skillset.gameObject.SetActive(false);
            } else {
                Pause();
            }
        }
    }

    public void ResetSkillChoices()
    {
        skillset = Instantiate(SkillSetPrefab);
        //skillset.Character = this;
    }




    
    public void Resume()
    {
        print("작동");
        //Destroy(skillset.gameObject);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }


    public void Pause()
    {
        skillset.gameObject.SetActive(true);
        //ResetSkillChoices();
        //Instantiate(AddSkillSetPrefab);
        
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SkillDraw()
    {
        
        
    }

    public void De()
    {

    }

    public void LevelUp()
    {
        Pause();
    }
/*
    public void Remove()
    {
        Destroy(SkillSetPrefab);
    }
    */
}