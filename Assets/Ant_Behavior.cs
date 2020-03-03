using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant_Behavior : MonoBehaviour
{
    public float speed = 2;
    public float range;
    public bool vertical;
    public bool startFlipped;

    private SpriteRenderer sr;
    private float startPos;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (vertical)
            startPos = transform.position.y;

        else
            startPos = transform.position.x;

        if (startFlipped)
        {
            if (vertical)
                sr.flipY = true;
            else
                sr.flipX = true;

            speed = -speed;
        }
    }

    void Update()
    {
        if (!vertical)
        {
            transform.position = new Vector2(transform.position.x + Time.deltaTime * speed, transform.position.y);
            if (transform.position.x >= startPos + range)
            {
                sr.flipX = true;
                speed = -Mathf.Abs(speed);
            }

            else if (transform.position.x <= startPos - range)
            {
                sr.flipX = false;
                speed = Mathf.Abs(speed);
            }
        }

        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * speed);
            if (transform.position.y >= startPos + range)
            {
                sr.flipY = true;
                speed = -Mathf.Abs(speed);
            }

            else if (transform.position.y < startPos - range)
            {
                sr.flipY = false;
                speed = Mathf.Abs(speed);
            }
        }
    }
}
