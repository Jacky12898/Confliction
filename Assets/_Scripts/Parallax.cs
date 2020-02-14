using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    public float effectStrength;
    private float length, startPosition;

    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float temp = cam.transform.position.x * (1 - effectStrength);
        float distance = cam.transform.position.x * effectStrength;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if (temp > startPosition + length)
            startPosition += length;

        else if (temp < startPosition - length)
            startPosition -= length;
    }
}
