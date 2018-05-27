﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Title screen script
/// </summary>
public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        // "Stage1" is the name of the first scene we created.
        SceneManager.LoadScene("Level1");
    }
    public void quitGame()
    {
        // "Stage1" is the name of the first scene we created.
        Application.Quit();
    }
}