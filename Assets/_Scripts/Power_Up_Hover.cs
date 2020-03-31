using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up_Hover : MonoBehaviour
{
    private float y;
    public float speed = 2f;

    void Start()
    {
        y = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, y + 0.1f * Mathf.Sin(speed * Time.time));
    }
}
