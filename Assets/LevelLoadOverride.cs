using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadOverride : MonoBehaviour
{
    private string levelName;

    void Start()
    {
        levelName = PlayerPrefs.GetString("LevelOverride");
        gameObject.name = levelName;
    }
}
