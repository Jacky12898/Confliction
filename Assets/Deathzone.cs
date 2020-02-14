using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (player.transform.position.y <= this.transform.position.y)
            Destroy(player);
    }
}
