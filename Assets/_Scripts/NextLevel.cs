using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = PlayerStats.p.player;

        if (gameObject.name.Contains("Cutscene"))
             player.SetActive(false);

        else
        {
            player.SetActive(true);
            player.transform.position = GameObject.Find("SpawnPoint").transform.position;
        }

        GameObject levelName = GameObject.Find("LevelName");
        if (levelName != null)
            levelName.GetComponent<Text>().text = gameObject.name;

        SceneManager.LoadScene(gameObject.name);
    }
}
