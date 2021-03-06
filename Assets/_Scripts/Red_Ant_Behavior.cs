﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Ant_Behavior : MonoBehaviour
{
    public float speed = 2;
    public float detectionRange;
    public bool startFlipped;

    private float startPos;
    private GameObject player;

    void Start()
    {
        startPos = transform.position.x;
        player = GameObject.Find("Player");

        if (startFlipped)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            speed = -speed;
        }
    }

    void Update()
    {
        if(Mathf.Abs(transform.position.x - player.transform.position.x) <= detectionRange && transform.position.y + 0.05f >= player.transform.position.y && transform.position.y - 0.05f <= player.transform.position.y && player.GetComponent<CharacterBehavior>().grounded)
        {
            if(player.transform.position.x - transform.position.x > 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
                speed = Mathf.Abs(speed);
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                speed = -Mathf.Abs(speed);
            }
                
            transform.position = new Vector2(transform.position.x + Time.deltaTime * speed * (1.75f), transform.position.y);
        }

        else
        {
            if (speed > 0)
                transform.rotation = new Quaternion(0, 180, 0, 0);
            else
                transform.rotation = new Quaternion(0, 0, 0, 0);

            transform.position = new Vector2(transform.position.x + Time.deltaTime * speed, transform.position.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name != "Ground")
        {
            speed = -speed;
            transform.rotation *= new Quaternion(0, 180, 0, 0);
        }
    }
}
