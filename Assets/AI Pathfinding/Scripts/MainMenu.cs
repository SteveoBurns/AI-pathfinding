using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
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
