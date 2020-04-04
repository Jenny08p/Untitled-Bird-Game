using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteract : MonoBehaviour
{
    /*
    public void StartGame(string level)
    {
        Application.LoadLevel("Main");
    }

    public void MainMenu(string level)
    {
        Application.LoadLevel("MainMenu");
    }
    */

    //John: Simplified the load function to one function
    public void LoadLevel(string level)
    {
        SceneManager.LoadSceneAsync(level);
    }

    //John: Removed the string parameter because you don't need it
    public void Exit()
    {
        Application.Quit();
    }
}
