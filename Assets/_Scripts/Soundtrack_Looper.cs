using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack_Looper : MonoBehaviour
{
    public AudioClip loopClip;
    public AudioClip introClip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = loopClip;
            audioSource.Play();
            audioSource.loop = true;
        }
    }
}
