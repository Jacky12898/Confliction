using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    float move = 0f;
    public Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    //bool inAir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkInAir();
        move = Input.GetAxisRaw("Horizontal") * speed;
        rb.velocity = new Vector2(move * Time.fixedDeltaTime * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(move));


        if(move > 0)
        {
            if (sr.flipX == true) sr.flipX = false;
            
        }

        else if (move < 0)
        {
            sr.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && !checkInAir())
        {
            rb.velocity = new Vector2(rb.velocity.x, Time.fixedDeltaTime * 600f);
        }
    }

    bool checkInAir()
    {
        if(rb.velocity.y >= 0.01 || rb.velocity.y <= -0.01)
        {
            animator.SetBool("InAir", true);
            return true;
        }
        animator.SetBool("InAir", false);
        return false;
    }
}
