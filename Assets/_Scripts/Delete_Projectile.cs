using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Projectile : MonoBehaviour
{
    public float decayTime = 3f;

    void Start()
    {
        Destroy(gameObject, decayTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
