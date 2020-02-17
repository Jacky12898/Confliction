using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public bool movement = true;
    public bool isAlive = true;
    public float speed;
    public GameObject jumpParticles;
    
    float move = 0f;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    int jumps = 1;
    int tempJumps = 1;
    //bool inAir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(movement == true)
        {
            checkInAir();
            move = Input.GetAxisRaw("Horizontal") * speed;
            rb.velocity = new Vector2(move * Time.fixedDeltaTime * speed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(move));


            if (move > 0)
            {
                if (sr.flipX == true) sr.flipX = false;
            }

            else if (move < 0)
            {
                sr.flipX = true;
            }

            if (Input.GetButtonDown("Jump") && tempJumps != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Time.fixedDeltaTime * 600f);
                if((jumps - tempJumps) != 0)
                {
                    GameObject particle = Instantiate<GameObject>(jumpParticles);
                    Vector3 particleOffset = new Vector3(0, -0.5f, 0);
                    particle.GetComponent<ParticleSystem>().transform.position = transform.position + particleOffset;
                    Destroy(particle, 1);
                }
                tempJumps--;
            }
        }
    }

    bool checkInAir()
    {
        if(rb.velocity.y >= 0.01 || rb.velocity.y <= -0.01)
        {
            animator.SetBool("InAir", true);
            return true;
        }
        tempJumps = jumps;
        animator.SetBool("InAir", false);
        return false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Obstacle")
        {
            movement = false;
            isAlive = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            switch (collision.gameObject.name)
            {
                case "Wing":
                    jumps++;
                    break;
            }

            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.tag == "Obstacle")
        {
            transform.position = GameObject.Find("SpawnPoint").transform.position;
        }
    }
}
