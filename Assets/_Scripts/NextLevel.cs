using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void Awake()
    {
        GameObject levelName = GameObject.Find("LevelName");
        if (levelName != null)
            levelName.GetComponent<Text>().text = SceneManager.GetActiveScene().name;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        GameObject player = GameObject.Find("Player");
        Destroy(player.gameObject);
        PlayerPrefs.SetString("NextLevel", gameObject.name);
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Level_Complete");
    }
}
