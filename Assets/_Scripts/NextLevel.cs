using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject levelName = GameObject.Find("LevelName");
        if (levelName != null)
            levelName.GetComponent<Text>().text = gameObject.name;

        SceneManager.LoadScene(gameObject.name);
    }
}
