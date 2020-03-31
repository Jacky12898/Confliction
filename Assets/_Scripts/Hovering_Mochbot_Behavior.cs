using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hovering_Mochbot_Behavior : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRange = 4f;
    public GameObject projectile;
    public float projectileSpeed = 5f;
    public float fireRate = 3f;

    private bool detected = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        Invoke("Shoot", fireRate);
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < detectionRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            detected = true;
        }

        else
            detected = false;
    }

    public void Shoot()
    {
        if (detected)
        {
            GameObject proj = Instantiate<GameObject>(projectile);
            proj.transform.position = transform.position;
            Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized * projectileSpeed;
        }

        Invoke("Shoot", fireRate);
    }
}
