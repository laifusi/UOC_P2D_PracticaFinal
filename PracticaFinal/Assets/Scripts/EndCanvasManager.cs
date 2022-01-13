using TMPro;
using UnityEngine;

public class EndCanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text toysCompletedText;
    [SerializeField] private TMP_Text partsWastedText;
    [SerializeField] private TMP_Text timeSpentText;

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
