using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    //public Cutscene cutscene;
    public AnimationClip[] animations;
    public Dialogue[] dialogues;

    //public Queue<string> animations;
    //public Queue<Dialogue> dialogues;
    private Animator anim;

    private int i = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        NextScene();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
        {
            i++;
            NextScene();
        }
    }

    //public void StartCutscene()
    //{
    //    //foreach(AnimationClip animation in cutscene.animations)
    //    //{
    //    //    animation.PlayQueued(animation.name);
    //    //    StartCoroutine(WaitForAnimation(animation));
    //    //}

    //    foreach (string animation in cutscene.animations)
    //    {
    //        animations.Enqueue(animation);
    //    }

    //    foreach (Dialogue dialogue in cutscene.dialogue)
    //    {
    //        dialogues.Enqueue(dialogue);
    //    }

    //    Time.timeScale = 0;
    //    GameObject.Find("Player").GetComponent<CharacterBehavior>().movement = false;
    //    NextScene();
    //}

    IEnumerator WaitForAnimation(string animation)
    {
        do
        {
            yield return null;
        } while (anim.GetCurrentAnimatorStateInfo(0).IsName(animation));
    }

    IEnumerator WaitForSecondsThenExecute(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues[i]);
    }

    public void NextScene()
    {
        if(dialogues.Length == i && animations.Length == i)
        {
            EndCutscene();
            return;
        }

        //for(int i = 0; i <= animations.Length - 1; i++)
        //{
        Debug.Log(animations[i].length);
        anim.Play(animations[i].name);
        //StartCoroutine(WaitForAnimation(animations[i].name));
        Debug.Log(dialogues[i].name);
        StartCoroutine(WaitForSecondsThenExecute(animations[i].length));

        //Dialogue dialogue = dialogues.Dequeue();
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogues[i]);
        //NextScene();
        //}

        //string animation = animations.Dequeue();
        Debug.Log(i);
    }

    public void EndCutscene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("");
    }
}
