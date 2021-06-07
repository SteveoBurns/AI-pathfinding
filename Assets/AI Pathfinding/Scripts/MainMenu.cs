using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads whichever scene is input
    /// </summary>
    /// <param name="_sceneName">name of the scene to load</param>
    public void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }

    /// <summary>
    /// Loads the Main Menu scene
    /// </summary>
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    /// <summary>
    /// Loads the game scene
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("Maze");
    }

    /// <summary>
    /// Quit from editor or application in build
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    
}
