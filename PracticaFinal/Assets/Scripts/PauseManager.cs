using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas; //Pause canvas
    [SerializeField] private GameObject openLetter; //Letter object, that also controls click detection
    
    /// <summary>
    /// Start method to initialize the canvas deactivated
    /// </summary>
    private void Start()
    {
        pauseCanvas.SetActive(false);
    }

    /// <summary>
    /// Method to pause the game
    /// We activate the canvas, deactivate our click detection and stop time
    /// </summary>
    public void PauseGame()
    {
        pauseCanvas.SetActive(true);
        MouseControl.Instance.DetectClicks = false;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Method to unpause the game
    /// We deactivate the canvas, activate the detection of clicks if the letter is not open and restart time
    /// </summary>
    public void UnpauseGame()
    {
        pauseCanvas.SetActive(false);
        if (!openLetter.activeInHierarchy)
            MouseControl.Instance.DetectClicks = true;

        Time.timeScale = 1;
    }
}
