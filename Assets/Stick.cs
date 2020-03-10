using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy")
        {
            transform.parent.GetComponent<CharacterBehavior>().animator.SetTrigger("SwingHit");
            transform.parent.GetComponent<CharacterBehavior>().sticks--;
            transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.GetComponent<Rigidbody2D>().velocity.x, Time.fixedDeltaTime * 620f);
        }
    }
}
