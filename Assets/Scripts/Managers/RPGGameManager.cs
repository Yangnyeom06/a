using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    //수정한 부분 <-----
    public RPGCameraManager cameraManager;
    //------>
    public static RPGGameManager sharedInstance = null;
    public SpawnPoint playerSpawnPoint;
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