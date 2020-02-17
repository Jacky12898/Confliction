using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Tutorial");
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
