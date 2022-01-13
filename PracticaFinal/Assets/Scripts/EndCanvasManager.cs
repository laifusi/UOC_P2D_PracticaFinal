using TMPro;
using UnityEngine;

public class EndCanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText; //Text that says if we won or lost
    [SerializeField] private TMP_Text toysCompletedText; //Text for statistics, number of toys completed
    [SerializeField] private TMP_Text partsWastedText; //Text for statistics, number of parts wasted
    [SerializeField] private TMP_Text timeSpentText; //Text for statistics, time spent

    /// <summary>
    /// Start method where we update the text to the data of the last game
    /// We use PlayerPrefs to see what the data is
    /// </summary>
    private void Start()
    {
        float timeLeft = PlayerPrefs.GetFloat("TimeLeft");
        if (timeLeft <= 0)
        {
            titleText.SetText("Te has quedado sin tiempo.");
        }
        else
        {
            titleText.SetText("Has ganado!");
        }

        toysCompletedText.SetText(PlayerPrefs.GetInt("ToysMadeRight").ToString());
        partsWastedText.SetText(PlayerPrefs.GetInt("PartsWasted").ToString());
        int timeUsed = (int)(PlayerPrefs.GetFloat("TotalTime") - timeLeft);
        timeSpentText.SetText(timeUsed.ToString() + " s");
    }
}
