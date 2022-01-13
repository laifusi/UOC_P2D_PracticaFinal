using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalMinutes;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private MenuManager menuManager;

    private float timeLeft;
    private int minutes, seconds;
    private string text;

    private void Start()
    {
        timeLeft = totalMinutes * 60;
    }

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

        if (seconds <= 0 && minutes <= 0)
        {
            menuManager.EndGame();
        }
    }
}
