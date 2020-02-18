﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;

    public Queue<string> sentences;

    void Start()
    {
        dialogueBox.SetActive(false);
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            DisplayNextSentence();

        else if (Input.GetKeyDown(KeyCode.Escape))
            EndDialogue();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Time.timeScale = 0;

        if(GameObject.Find("Player") != null)
            GameObject.Find("Player").GetComponent<CharacterBehavior>().movement = false;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Time.timeScale = 1;
        if (GameObject.Find("Player") != null)
            GameObject.Find("Player").GetComponent<CharacterBehavior>().movement = true;
        dialogueBox.SetActive(false);
    }
}