using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public AnimationClip[] animations;
    public Dialogue[] dialogues;
    public string nextScene = "";
    public string playerPrefName;
    public string playerPrefValue;

    private Animator anim;
    private bool dialogueEnd = true;

    private int i = 0;

    void Start()
    {
        PlayerPrefs.SetString(playerPrefName, playerPrefValue);
        anim = GetComponent<Animator>();
        NextScene();
    }

    void Update()
    {
        if (dialogueEnd && !FindObjectOfType<DialogueManager>().dialogueActive)
        {
            i++;
            NextScene();
        }
    }

    IEnumerator WaitForAnimation(float waitTime)
    {
        yield return new WaitForSeconds(waitTime - 0.05f);
        try
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogues[i]);
            dialogueEnd = true;
        }

        catch
        {
            EndCutscene();
        }
    }

    public void NextScene()
    {
        dialogueEnd = false;
        if(animations.Length == i)
        {
            EndCutscene();
            return;
        }

        anim.Play(animations[i].name);
        StartCoroutine(WaitForAnimation(animations[i].length));
    }

    public void EndCutscene()
    {
        Time.timeScale = 1;

        GameObject levelName = GameObject.Find("LevelName");
        if (levelName != null)
            levelName.GetComponent<Text>().text = gameObject.name;

        if(PlayerPrefs.GetString("Choice") == "")
            SceneManager.LoadScene(nextScene);

        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("Choice"));
        }
    }
}
