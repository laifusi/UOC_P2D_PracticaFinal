using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] MenuManager menuManager;

    private int toysMadeRight;
    private int partsWasted;
    private float timeLeft;

    private void Start()
    {
        Timer.OnTimeChanged += TimeUpdated;
        WrapPoint.OnToyMadeRight += UpdateToysMadeRight;
        WrapPoint.OnToyMadeWrong += UpdatePartsWasted;
        Trash.OnPartThrown += UpdatePartsWasted;
    }

    private void TimeUpdated(float time)
    {
        timeLeft = time;
    }

    private void UpdateToysMadeRight()
    {
        toysMadeRight++;
    }

    private void UpdatePartsWasted(int parts)
    {
        partsWasted += parts;
    }

    public void EndGame()
    {
        PlayerPrefs.SetFloat("TimeLeft", timeLeft);
        PlayerPrefs.SetInt("ToysMadeRight", toysMadeRight);
        PlayerPrefs.SetInt("PartsWasted", partsWasted);
        PlayerPrefs.SetFloat("TotalTime", Timer.TotalTime);
        menuManager.EndGame();
    }

    private void OnDestroy()
    {
        Timer.OnTimeChanged -= TimeUpdated;
        WrapPoint.OnToyMadeRight -= UpdateToysMadeRight;
        WrapPoint.OnToyMadeWrong -= UpdatePartsWasted;
        Trash.OnPartThrown -= UpdatePartsWasted;
    }
}
