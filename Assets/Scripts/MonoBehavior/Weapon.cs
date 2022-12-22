using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Vector2 movement = new Vector2();
    int move_x;
    int move_y;
    public int shootDistance = 5;
    public float shootDelay = 0.5f;
    public int shoot = 3;
    int shoot_x;
    int shoot_y;
    float rotation_left = 0;
    float rotation_right = 0;
    float rotation_horizon = 0;

    public GameObject ammoPrefab;
    static List<GameObject> ammoPool;
    public int poolSize;
    public float weaponSpeed;
    public bool samdusa = true;
    bool a = true;
    MoveDirController moveDirController;
    public void OnEnable()
    {
        if (ammoPool == null)
        {
            ammoPool = new List<GameObject>();
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject ammoObject = Instantiate(ammoPrefab);
            ammoObject.SetActive(false);
            ammoPool.Add(ammoObject);
        }
    }
    
    GameObject SpawnAmmo(Vector3 location)
    {
        foreach (GameObject ammo in ammoPool)
        {
            if (ammo.activeSelf == false)
            {
                ammo.SetActive(true);
                ammo.transform.position = location;
                return ammo;
            }
        }
        return null;
    }
    public void Start()
    {
        moveDirController = GetComponent<MoveDirController>();
        InvokeRepeating("FireAmmo", 0, shootDelay);
        InvokeRepeating("FireAmmo", 0.2f, shootDelay);
        InvokeRepeating("FireAmmo", 0.7f, shootDelay);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)){
                if (a == true)
                {
                    a = false;
                }
                else 
                {
                    a = true;
                }
            }
        Movement();
    }


    public void OnDestroy()
    {
        if (this.gameObject.activeInHierarchy)
        {
            ammoPool = null;
        }
    }



    public void Movement()
    {
        if (a == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if ((movement.x > 0) && (movement.y > 0)) // 오른쪽 위
            {
                move_x = shootDistance;
                move_y = shootDistance;
                shoot_x = shoot;
                shoot_y = -shoot;
                rotation_left = -25;
                rotation_right = -65;
                rotation_horizon = -45;

            }
            if ((movement.x > 0) && (movement.y < 0)) // 오른쪽 아래
            {
                move_x = shootDistance;
                move_y = -shootDistance;
                shoot_x = shoot;
                shoot_y = shoot;
                rotation_left = -155;
                rotation_right = -115;
                rotation_horizon = 45;
            }
            if ((movement.x < 0) && (movement.y > 0)) // 왼쪽 위
            {
                move_x = -shootDistance;
                move_y = shootDistance;
                shoot_x = -shoot;
                shoot_y = -shoot;
                rotation_left = 25;
                rotation_right = 65;
                rotation_horizon = 45;
            }
            if ((movement.x < 0) && (movement.y < 0)) // 왼쪽 아래
            {
                move_x = -shootDistance;
                move_y = -shootDistance;
                shoot_x = -shoot;
                shoot_y = shoot;
                rotation_left = 155;
                rotation_right = 115;
                rotation_horizon = -45;
            }
            if ((movement.x > 0) && (movement.y == 0)) // 오른쪽
            {
                move_x = shootDistance;
                move_y = 0;
                shoot_x = 0;
                shoot_y = -shoot;
                rotation_left = -75;
                rotation_right = 75;
                rotation_horizon = 90;
            }
            if ((movement.x < 0) && (movement.y == 0)) // 왼쪽
            {
                move_x = -shootDistance;
                move_y = 0;
                shoot_x = 0;
                shoot_y = shoot;
                rotation_left = -75;
                rotation_right = 75;
                rotation_horizon = 90;
            }
            if ((movement.x == 0) && (movement.y > 0)) // 위쪽
            {
                move_x = 0;
                move_y = shootDistance;
                shoot_x = shoot;
                shoot_y = 0;
                rotation_left = 15;
                rotation_right = -15;
                rotation_horizon = 0;
            }
            if ((movement.x == 0) && (movement.y < 0)) // 아래쪽
            {
                move_x = 0;
                move_y = -shootDistance;
                shoot_x = -shoot;
                shoot_y = 0;
                rotation_left = 15;
                rotation_right = -15;
                rotation_horizon = 0;
            }
            if ((movement.x == 0) && (movement.y == 0))
            {
                return;
            }
        }
    }

    public void FireAmmo()
    {
        GameObject ammo = SpawnAmmo(transform.position);
        Vector3 Position = new Vector3(ammo.transform.position.x + move_x, ammo.transform.position.y + move_y);
        //print(Position);

        if (ammo != null)
        {
            Arc arcScript = ammo.GetComponent<Arc>();
            arcScript.transform.rotation = Quaternion.Euler(0, 0, rotation_horizon);

            float travelDuration = 1.0f / weaponSpeed;
            StartCoroutine(arcScript.TravelArc(Position, travelDuration));
        }
        
        if (samdusa == true)
        {
            FireAmmoLeft();
            FireAmmoRight();
        }
    }
    public void FireAmmoLeft()
    {
        GameObject ammo = SpawnAmmo(transform.position);
        Vector3 Position = new Vector3(ammo.transform.position.x - shoot_x + move_x, ammo.transform.position.y - shoot_y + move_y);
        if (ammo != null)
        {
            Arc arcScript = ammo.GetComponent<Arc>();
            arcScript.transform.rotation = Quaternion.Euler(0, 0, rotation_left);

            float travelDuration = 1.0f / weaponSpeed;
            StartCoroutine(arcScript.TravelArc(Position, travelDuration));
        }
    }
    public void FireAmmoRight()
    {
        GameObject ammo = SpawnAmmo(transform.position);
        Vector3 Position = new Vector3(ammo.transform.position.x + shoot_x + move_x, ammo.transform.position.y + shoot_y + move_y);
        if (ammo != null)
        {
            Arc arcScript = ammo.GetComponent<Arc>();
            arcScript.transform.rotation = Quaternion.Euler(0, 0, rotation_right);
            float travelDuration = 1.0f / weaponSpeed;
            StartCoroutine(arcScript.TravelArc(Position, travelDuration));
        }
    }
}