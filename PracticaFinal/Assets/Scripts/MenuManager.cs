using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Method to go to the Menu
    /// </summary>
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Method to load the Game scene
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Method to load the end scene
    /// </summary>
    public void EndGame()
    {
        SceneManager.LoadScene("End");
    }

    /// <summary>
    /// Method to close the application
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
