using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Projectile : MonoBehaviour
{
    public float decayTime = 3f;

    void Start()
    {
        Destroy(this.gameObject, decayTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
