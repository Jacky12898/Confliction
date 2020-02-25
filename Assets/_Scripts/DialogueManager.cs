using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    public GameObject choice_1;
    public GameObject choice_2;
    public GameObject next;
    public GameObject skip;
    public bool dialogueActive = false;

    public Queue<string> sentences;

    void Start()
    {
        dialogueBox.SetActive(false);
        choice_1.SetActive(false);
        choice_2.SetActive(false);
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
            if (sentence.Contains("<"))
                skip.SetActive(false);
            sentences.Enqueue(sentence);
        }
        Time.timeScale = 0;

        if(GameObject.Find("Player") != null)
            GameObject.Find("Player").GetComponent<CharacterBehavior>().movement = false;
        DisplayNextSentence();
        dialogueActive = true;
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
        if (sentence.Contains("<"))
            StartCoroutine(PresentChoices(sentence));

        else
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

    IEnumerator PresentChoices(string sentence)
    {
        next.SetActive(false);
        skip.SetActive(false);

        choice_1.SetActive(true);
        choice_2.SetActive(true);
        choice_1.GetComponent<Text>().text = sentence.Substring(1, sentence.IndexOf('/') - 1);
        choice_2.GetComponent<Text>().text = sentence.Substring(sentence.IndexOf('/') + 1);
        yield return null;
    }

    public void Choice_1()
    {
        DisplayNextSentence();
        sentences.Dequeue();

        next.SetActive(true);
        skip.SetActive(true);
        choice_1.SetActive(false);
        choice_2.SetActive(false);
    }

    public void Choice_2()
    {
        sentences.Dequeue();
        DisplayNextSentence();

        next.SetActive(true);
        skip.SetActive(true);
        choice_1.SetActive(false);
        choice_2.SetActive(false);
    }

    public void EndDialogue()
    {
        Time.timeScale = 1;
        
        dialogueBox.SetActive(false);
        dialogueActive = false;
        if (GameObject.Find("Player") != null)
            GameObject.Find("Player").GetComponent<CharacterBehavior>().movement = true;
    }
}