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


    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
        if (SkillSetPrefab.activeSelf == false)
        {
            GameIsPaused = false;
            Time.timeScale = 1f;
        }
    }

    public void Resume(){
        Destroy(SkillSetPrefab);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause(){
        Instantiate(SkillSetPrefab);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LevelUp()
    {
        if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
    }

    public void Remove()
    {
        Destroy(SkillSetPrefab.gameObject);
    }
}