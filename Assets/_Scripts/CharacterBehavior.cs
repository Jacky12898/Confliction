using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public bool movement = true;
    public bool grounded = true;
    public float speed;
    public int sticks = 0;
    public int bubbles = 0;
    public GameObject jumpParticles;
    
    float move = 0f;
    public Animator animator;
    private Rigidbody2D rb;

    int jumps = 1;
    int tempJumps = 1;
    bool rocketReady = false;

    void Start()
    {
        DontDestroyOnLoad(this);
        rb = GetComponent<Rigidbody2D>();
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
                transform.rotation = Quaternion.Euler(0, 0, 0);

            else if (move < 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);

            if (Input.GetButtonDown("Jump") && tempJumps != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Time.fixedDeltaTime * 620f);
                if((jumps - tempJumps) != 0)
                {
                    GameObject particle = Instantiate<GameObject>(jumpParticles);
                    Vector3 particleOffset = new Vector3(0, -0.5f, 0);
                    particle.GetComponent<ParticleSystem>().transform.position = transform.position + particleOffset;
                    Destroy(particle, 1);
                }
                tempJumps--;
            }

            if (Input.GetKeyDown(KeyCode.S) && !grounded && sticks > 0)
            {
                animator.SetTrigger("SwingStick");
                Debug.Log(sticks.ToString());
            }

            if(Input.GetKeyDown(KeyCode.LeftShift) && rocketReady)
            {
                rb.velocity = new Vector2(move * Time.fixedDeltaTime * 4f * speed, 0);
                rocketReady = false;
                StartCoroutine(RocketBoost());
                StartCoroutine(ResetRocketBoost());
            }
        }
    }

    bool checkInAir()
    {
        if(rb.velocity.y >= 0.01 || rb.velocity.y <= -0.01)
        {
            animator.SetBool("InAir", true);
            grounded = false;
            return true;
        }
        tempJumps = jumps;
        grounded = true;
        animator.SetBool("InAir", false);
        animator.SetTrigger("SwingHit");
        return false;
    }

    IEnumerator RocketBoost()
    {
        movement = false;
        rb.gravityScale = 0;
        yield return new WaitForSecondsRealtime(0.2f);
        rb.gravityScale = 3;
        movement = true;
    }

    IEnumerator ResetRocketBoost()
    {
        yield return new WaitForSecondsRealtime(3f);
        rocketReady = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile" && bubbles != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Time.fixedDeltaTime * 620f);
            bubbles--;
        }

        else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Obstacle")
        {
            StartCoroutine(death());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            switch (collision.gameObject.name)
            {
                case string x when x.Contains("Wing"):
                    jumps++;
                    break;
                case string x when x.Contains("Stick"):
                    sticks++;
                    break;
                case string x when x.Contains("Bubble"):
                    bubbles++;
                    break;
                case string x when x.Contains("Rocket"):
                    rocketReady = true;
                    break;
                default:
                    break;
            }
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.tag == "Obstacle")
        {
            StartCoroutine(death());
        }
    }

    IEnumerator death()
    {
        movement = false;
        Time.timeScale = 0;
        animator.Play("Player_Death", 0);
        yield return new WaitForSecondsRealtime(0.5f);
        movement = true;
        transform.position = GameObject.Find("SpawnPoint").transform.position;
        Time.timeScale = 1;
    }
}
