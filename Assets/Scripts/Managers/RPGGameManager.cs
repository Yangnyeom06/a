using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    public RPGCameraManager cameraManager;
    public static RPGGameManager sharedInstance = null;
    public SpawnPoint playerSpawnPoint;
    public GameObject SkillSetPrefab;
    //public Inventory inventoryPrefab;
    public HealthBar healthBarPrefab;
    public ExpBar expBarPrefab;
    public static bool GameIsPaused = false;
    Player player1;
    
    void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        SetupScene();
    }

/*
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

    public void Resume(){
        SkillSetPrefab.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause(){
        SkillSetPrefab.SetActive(true);
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
 */   

    public void SetupScene()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();

            // 수정한 부분 <------
            cameraManager.virtualCamera.Follow = player.transform;
            // ------>
        }

    }
}