using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Sound_Controller : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
