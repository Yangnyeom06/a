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
    SkillList skill;

    public int SkillCount;
    private int draw;
    
    void Start()
    {
        List<int> Skill_List = new List<int>();
        for (int i = 0; i < SkillCount; ++i)
        {
            Skill_List.Add(i);
        }
        skillset = Instantiate(SkillSetPrefab);
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
        draw = Random.Range(0, 3);

        switch (draw)
        {
            case 0:
                skill.Skill1();
                break;
                
            case 1:
                skill.Skill2();
                break;

            case 2:
                skill.Skill3();
                break;
        }
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


    public void LevelUp()
    {
        Pause();
    }
}