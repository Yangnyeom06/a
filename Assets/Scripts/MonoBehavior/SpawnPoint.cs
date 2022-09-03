using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    float currentTime;
    public float createTime = 1;
    public float maxTime;
    public float minTime;
    public float repeatInterval;

    public void Start()
    {
        createTime = UnityEngine.Random.Range(minTime, maxTime);

        if(createTime > 0)
        {
            InvokeRepeating("SpawnObject", 0.0f, createTime);
        }
    }

    public GameObject SpawnObject()
    {
        if(prefabToSpawn != null)
        {
            return Instantiate(prefabToSpawn,transform.position, Quaternion.identity);
        }

        return null;
    }
}