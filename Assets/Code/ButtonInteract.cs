using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteract : MonoBehaviour
{
    public void StartGame(string level)
    {
        Application.LoadLevel("Main");
    }

    public void MainMenu(string level)
    {
        Application.LoadLevel("MainMenu");
    }

    public void Exit(string level)
    {
        Application.Quit();
    }
}
