using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    private float speed;

    public float dashSpeed = 50.0f;
    public float dashTime;
    public Vector2 movement;
    Rigidbody2D rigid2D;

    Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        speed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash(dashTime));
        }
        UpdateState();
    }

    private void FixedUpdate()
    {
        
        MoveCharacter();

    }


    public IEnumerator Dash(float duration)
    {
        float time = 0.0f;
        while (time < 1.0f)
        {
            time += Time.deltaTime / duration;

            movementSpeed = dashSpeed;

            yield return null;
        }
        movementSpeed = speed;
    }
    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rigid2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {

        if (Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0))
        {
            animator.SetBool("isMove", false);
        }
        else
        {
            animator.SetBool("isMove", true);
        }
        animator.SetFloat("xDir", movement.x);
        animator.SetFloat("yDir", movement.y);

    }
}