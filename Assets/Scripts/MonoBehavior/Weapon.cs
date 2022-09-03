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
    public GameObject ammoPrefab;
    static List<GameObject> ammoPool;
    public int poolSize;
    public float weaponSpeed;
    MoveDirController moveDirController;
    void Awake()
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
    
    void Start()
    {
        moveDirController = GetComponent<MoveDirController>();
        InvokeRepeating("FireAmmo", 0, shootDelay);
        InvokeRepeating("FireAmmo", 0.2f, shootDelay);
        InvokeRepeating("FireAmmo", 0.7f, shootDelay);
    }

    void Update()
    {
        Movement();
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

    void OnDestroy()
    {
        ammoPool = null;
    }

    private void OnEnable()
    {
        FireAmmo();
    }

    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if ((movement.x > 0) && (movement.y > 0)) // 오른쪽 위
        {
            move_x = shootDistance;
            move_y = shootDistance;
        }
        if ((movement.x > 0) && (movement.y < 0)) // 오른쪽 아래
        {
            move_x = shootDistance;
            move_y = -shootDistance;
        }
        if ((movement.x < 0) && (movement.y > 0)) // 왼쪽 위
        {
            move_x = -shootDistance;
            move_y = shootDistance;
        }
        if ((movement.x < 0) && (movement.y < 0)) // 왼쪽 아래
        {
            move_x = -shootDistance;
            move_y = -shootDistance;
        }
        if ((movement.x > 0) && (movement.y == 0)) // 오른쪽
        {
            move_x = shootDistance;
            move_y = 0;
        }
        if ((movement.x < 0) && (movement.y == 0)) // 왼쪽
        {
            move_x = -shootDistance;
            move_y = 0;
        }
        if ((movement.x == 0) && (movement.y > 0)) // 위쪽
        {
            move_x = 0;
            move_y = shootDistance;
        }
        if ((movement.x == 0) && (movement.y < 0)) // 아래쪽
        {
            move_x = 0;
            move_y = -shootDistance;
        }
        if ((movement.x == 0) && (movement.y == 0))
        {
            return;
        }
    }

    void FireAmmo()
    {
        
        


        GameObject ammo = SpawnAmmo(transform.position);
        Vector2 mousePosition = new Vector2(ammo.transform.position.x + move_x, ammo.transform.position.y + move_y);
        print(mousePosition);

        if (ammo != null)
        {
            Arc arcScript = ammo.GetComponent<Arc>();
            float travelDuration = 1.0f / weaponSpeed;
            StartCoroutine(arcScript.TravelArc(mousePosition, travelDuration));
        }
    }
}