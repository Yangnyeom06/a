using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillSetPrefab;
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

    }
    void Update()
    {

    }

    
    public void Resume()
    {
        Destroy(SkillSetPrefab);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        SkillDraw();
        Instantiate(SkillSetPrefab);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SkillDraw()
    {
        
        
    }

    public void LevelUp()
    {
        if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
    }
/*
    public void Remove()
    {
        Destroy(SkillSetPrefab);
    }
    */
}