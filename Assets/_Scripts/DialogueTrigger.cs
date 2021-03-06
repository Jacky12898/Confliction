﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            GameObject.Find("Player").GetComponent<CharacterBehavior>().inDialogue = true;
            Destroy(this.gameObject);
        }
    }
}