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
            if (!vertical)
                transform.rotation = new Quaternion(0, 180, 0, 0);
            else
                transform.rotation = new Quaternion(0, 0, 90, 0);

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
                transform.rotation = new Quaternion(0, 0, 0, 0);
                speed = -Mathf.Abs(speed);
            }

            else if (transform.position.x <= startPos - range)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
                speed = Mathf.Abs(speed);
            }
        }

        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * speed);
            if (transform.position.y >= startPos + range)
            {
                transform.rotation = new Quaternion(0, 0, -90, 0);
                speed = -Mathf.Abs(speed);
            }

            else if (transform.position.y < startPos - range)
            {
                transform.rotation = new Quaternion(0, 0, 90, 0);
                speed = Mathf.Abs(speed);
            }
        }
    }
}
