using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalMinutes; //total of minutes the game can last
    [SerializeField] private TMP_Text timerText; //timer Text
    [SerializeField] private GameManager gameManager; //GameManager to call when we run out of time

    private float timeLeft; //time left
    private int minutes, seconds; //minutes and seconds left
    private string text; //string to write on the Text

    public static Action<float> OnTimeChanged; //Action called when the time changes
    public static float TotalTime; //number of total time in seconds

    /// <summary>
    /// Method to initialize the TotalTime and the timeLeft
    /// </summary>
    private void Start()
    {
        TotalTime = timeLeft = totalMinutes * 60;
    }

    /// <summary>
    /// Update method where we update the time left
    /// We write it as mm:ss in the Text
    /// If we ran out of time, we lose the game
    /// </summary>
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        minutes = (int)(timeLeft / 60);
        seconds = (int)(timeLeft - (minutes * 60));
        if (minutes > 9)
            text = minutes.ToString();
        else
            text = "0" + minutes.ToString();
        text += ":";
        if (seconds > 9)
            text += seconds.ToString();
        else
            text += "0" + seconds.ToString();

        timerText.SetText(text);

        OnTimeChanged?.Invoke(timeLeft);

        if (seconds <= 0 && minutes <= 0)
        {
            gameManager.EndGame();
        }
    }
}
