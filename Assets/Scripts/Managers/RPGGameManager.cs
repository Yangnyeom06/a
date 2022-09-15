using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    public RPGCameraManager cameraManager;
    public static RPGGameManager sharedInstance = null;
    public SpawnPoint playerSpawnPoint;
    public GameObject SkillChoiceSet;
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

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (SkillChoiceSet.activeSelf)
                SkillChoiceSet.SetActive(false);
            else SkillChoiceSet.SetActive(true);
            {
                Time.timeScale = 0;
            }
        }
    }

    public void LevelUp()
    {
        Time.timeScale = 0;
        SkillChoiceSet.SetActive(true);
    }

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