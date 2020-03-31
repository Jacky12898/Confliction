using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject player;
    public static PlayerStats p;

    void Start()
    {
        p = this;
        p.player = GameObject.Find("Player");
        p.player.SetActive(false);
        Debug.Log(p.player.name);
    }

    int jumps = 1;
    int bubbles = 0;
    int sticks = 0;

    public void setJumps(int amount)
    {
        p.jumps = amount;
    }

    public void setBubbles(int amount)
    {
        p.bubbles = amount;
    }

    public void setSticks(int amount)
    {
        p.sticks = amount;
    }

    public void Reset()
    {
        p.jumps = 1;
        p.bubbles = 0;
        p.sticks = 0;
    }

    //public GameObject FindPlayer()
    //{
    //    GameObject[] allGameObjects = GameObject.FindObjectsOfTypeAll<GameObject>();
    //    foreach (GameObject obj in allGameObjects)
    //    {
    //        if (obj.name == "Player")
    //            return obj;
    //    }

    //    return new GameObject();
    //}
}
