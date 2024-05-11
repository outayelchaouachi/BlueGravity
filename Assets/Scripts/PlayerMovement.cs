using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetAxisRaw("Horizontal") > 0 && faceLeft)
        {
            Flip();
            faceLeft = false;
        }
        if(Input.GetAxisRaw("Horizontal") < 0 && !faceLeft)
        {
            Flip();
            faceLeft= true;
        }
        // Update animator parameters based on movement
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        dir.x = (Input.GetAxisRaw("Horizontal"));
        dir.y = (Input.GetAxisRaw("Vertical"));
        rb.velocity = dir;
    }
    private void Flip()
    {
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;    
    }

}
