using System.Collections;
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
        float moveHorizontal = Input.GetAxis("Horizontal");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        Debug.Log(dialogue.ToString());
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Time.timeScale = 0;
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
        GameObject.Find("Player").GetComponent<CharacterBehavior>().movement = true;
        dialogueBox.SetActive(false);
    }
}