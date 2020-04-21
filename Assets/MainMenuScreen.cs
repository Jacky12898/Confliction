using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    public float speed = 1f;
    public GameObject[] backgrounds;
    int index = 0;

    void Start()
    {
        Invoke("ChangeBG", 0);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, 0, -10);
    }

    void ChangeBG()
    {
        if (index > 4)
            index = 0;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(false);
            if(i == index)
                backgrounds[index].SetActive(true);
        }
        index++;
        Invoke("ChangeBG", 3.42862f);
    }
}
