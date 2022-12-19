using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    //public RPGCameraManager cameraManager;
    public static RPGGameManager sharedInstance = null;
    public PlayerRespawn playerSpawnPoint;
    //public Inventory inventoryPrefab;
    public HealthBar healthBarPrefab;
    public ExpBar expBarPrefab;
    public static bool GameIsPaused = false;
    public static RPGGameManager instance;
    public MoveController move;

    
    void Awake()
    {
        instance = this;
        
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }
/*
    void Start()
    {
        SetupScene();
    }
public void SetupScene()
    {
        SpawnPlayer();
    }
public void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            //GameObject player = playerSpawnPoint.player;

            // 수정한 부분 <------
            cameraManager.virtualCamera.Follow = playerSpawnPoint.player.transform;
            // ------>
        }

    }*/
}

/*     void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }
    public void Resume()
    {
        print("작동");

        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }


    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

*/
   





/*
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
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

