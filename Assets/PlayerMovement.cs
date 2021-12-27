using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    private float x = 1, y= 1;
    private Animator animator;
    void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // input
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        movement.x = x;
        movement.y = y;
        animator.SetFloat("x",x);
        animator.SetFloat("y",y);
        if( Mathf.Abs(x) > 0 || Mathf.Abs(y) > 0){
            animator.SetBool("isWalking",true);
        }else{
            animator.SetBool("isWalking",false);
        }
    }

    void FixedUpdate()
    {
        // movement
        rb.MovePosition(rb.position + movement * moveSpeed);
    }
}
