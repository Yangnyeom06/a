using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    //Rigidbody2D rigid2D;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        //rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        //rigid2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {

        if (Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0))
        {
            animator.SetBool("isMove", false);
        
            return;
        }
        else
        {
            animator.SetBool("isMove", true);
        }
    
        animator.SetFloat("xDir", movement.x);
        animator.SetFloat("yDir", movement.y);

    }
}