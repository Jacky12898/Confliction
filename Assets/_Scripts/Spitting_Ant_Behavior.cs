using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitting_Ant_Behavior : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 5f;
    public float fireRate = 3f;
    public int xDirection = 0;
    public int yDirection = 0;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("Shoot", fireRate);
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject proj = Instantiate<GameObject>(projectile);
        proj.transform.position = transform.position;

        if (yDirection != 0)
            proj.transform.Rotate(Vector3.forward * -90);

        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xDirection * projectileSpeed, yDirection * projectileSpeed);
        anim.Play("Spitting_Ant_Shoot", 0);

        Invoke("Shoot", fireRate);
    }
}
