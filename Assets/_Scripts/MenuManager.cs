using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    public void NewGame()
    {
        player = PlayerStats.p.player;
        player.SetActive(true);
        SceneManager.LoadScene("Tutorial");
        player.transform.position = new Vector3(-3.5f,3.5f,0);
        player.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        
        GameObject levelName = GameObject.Find("LevelName");
        if (levelName != null)
            levelName.GetComponent<Text>().text = "Tutorial";

        PlayerStats.p.Reset();
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
