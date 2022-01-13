using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject openLetter;
    

    private void Start()
    {
        pauseCanvas.SetActive(false);
    }

    public void PauseGame()
    {
        pauseCanvas.SetActive(true);
        MouseControl.Instance.DetectClicks = false;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        pauseCanvas.SetActive(false);
        if (!openLetter.activeInHierarchy)
            MouseControl.Instance.DetectClicks = true;

        Time.timeScale = 1;
    }
}
