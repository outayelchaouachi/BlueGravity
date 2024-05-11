using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.5f;
    Rigidbody2D rb;
    Animator animator;

    Vector2 dir =Vector2.zero;

    private bool faceLeft=false;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckAndFlipPlayer();
        Animate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    //Move the player with rigidbody
    private void Move()
    {
        dir.x = (Input.GetAxisRaw("Horizontal"));
        dir.y = (Input.GetAxisRaw("Vertical"));
        rb.velocity = dir * speed;
    }

    //Check wher the player is facing and face him accordingly
    private void CheckAndFlipPlayer()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && faceLeft)
        {
            Flip();
            faceLeft = false;
        }
        if (Input.GetAxisRaw("Horizontal") < 0 && !faceLeft)
        {
            Flip();
            faceLeft = true;
        }
    }

    //Flips the player left & right
    private void Flip()
    {
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;    
    }

    // Update animator parameters based on movement
    private void Animate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
