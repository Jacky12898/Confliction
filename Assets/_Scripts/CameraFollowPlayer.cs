using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private GameObject player;
    public float smoothSpeed = 0.2f;
    public Vector3 offset;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if(player != null)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
