using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D col;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if(transform.parent.GetComponent<CharacterBehavior>().bubbles == 0)
        {
            sr.enabled = false; 
            col.enabled = false;
        }

        else
        {
            sr.enabled = true;
            col.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile" && transform.parent.GetComponent<CharacterBehavior>().bubbles > 0)
        {
            transform.parent.GetComponent<CharacterBehavior>().soundController.clip = transform.parent.GetComponent<CharacterBehavior>().bubbleAudio;
            transform.parent.GetComponent<CharacterBehavior>().soundController.Play();
            transform.parent.GetComponent<CharacterBehavior>().bubbles--;
            DestroyImmediate(collision.gameObject);
            transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.GetComponent<Rigidbody2D>().velocity.x, Time.fixedDeltaTime * 620f);
        }
    }
}
