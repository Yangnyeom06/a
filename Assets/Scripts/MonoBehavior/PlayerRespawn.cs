using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public GameObject player;
    public RPGCameraManager cameraManager;

    void Start()
    {
        player = Instantiate(charPrefabs[(int) DataManager.instance.currentCharacter]);
        player.transform.position = transform.position;
        
        player.GetComponent<SelectCharacter>().enabled = false;
        player.GetComponent<MoveController>().enabled = true;
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<Weapon>().enabled = true;
        player.GetComponent<SkillList>().enabled = true;
        player.GetComponent<CardInventory>().enabled = true;
        

        player.transform.Find("direction1").gameObject.SetActive(true);
        //player.transform.Find("Area").gameObject.SetActive(true);

        cameraManager.virtualCamera.Follow = player.transform;
    }

}
