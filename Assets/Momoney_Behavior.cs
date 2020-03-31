using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momoney_Behavior : MonoBehaviour
{
    public AnimationClip[] attacks;
    public GameObject stick;
    private Animator anim;
    int index = 0;
    int health = 5;
    int spawnStick = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        index = Random.Range(0, 3);
        StartCoroutine(Attack(index));
    }

    IEnumerator Attack(int index)
    {
        if (index == 1 && transform.position.x > 0)
            index = 2;

        else if (index == 2 && transform.position.x < 0)
            index = 1;

        anim.Play(attacks[index].name);
        yield return new WaitForSeconds(attacks[index].length);
        index = Random.Range(0, 3);
        spawnStick = Random.Range(0, 3);

        if (spawnStick == 0)
            SpawnStick();

        StartCoroutine(Attack(index));
    }

    void SpawnStick()
    {
        GameObject newStick = Instantiate<GameObject>(stick);
        newStick.transform.position = new Vector2(0, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            health--;
        }

        if(health <= 0 && GameObject.Find("Player") != null)
        {

        }
    }
}
