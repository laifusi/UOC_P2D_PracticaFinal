using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] MenuManager menuManager; //MenuManager to call to change scenes

    private int toysMadeRight; //number of toys correctly made
    private int partsWasted; //number of toy parts wasted
    private float timeLeft; //time left of the game

    /// <summary>
    /// Start method to subscribe to Actions
    /// </summary>
    private void Start()
    {
        Timer.OnTimeChanged += TimeUpdated;
        WrapPoint.OnToyMadeRight += UpdateToysMadeRight;
        WrapPoint.OnToyMadeWrong += UpdatePartsWasted;
        Trash.OnPartThrown += UpdatePartsWasted;
    }

    /// <summary>
    /// Method to update the time left
    /// </summary>
    /// <param name="time">time left</param>
    private void TimeUpdated(float time)
    {
        timeLeft = time;
    }

    /// <summary>
    /// Method to update the number of toys correctly finished
    /// </summary>
    private void UpdateToysMadeRight()
    {
        toysMadeRight++;
    }

    /// <summary>
    /// Method to update the number of parts wasted
    /// </summary>
    /// <param name="parts">parts wasted</param>
    private void UpdatePartsWasted(int parts)
    {
        partsWasted += parts;
    }

    /// <summary>
    /// Method to end the game
    /// We save the data and call the MenuManager to change scenes
    /// </summary>
    public void EndGame()
    {
        PlayerPrefs.SetFloat("TimeLeft", timeLeft);
        PlayerPrefs.SetInt("ToysMadeRight", toysMadeRight);
        PlayerPrefs.SetInt("PartsWasted", partsWasted);
        PlayerPrefs.SetFloat("TotalTime", Timer.TotalTime);
        menuManager.EndGame();
    }

    /// <summary>
    /// OnDestroy method to unsubscribe from Actions
    /// </summary>
    private void OnDestroy()
    {
        Timer.OnTimeChanged -= TimeUpdated;
        WrapPoint.OnToyMadeRight -= UpdateToysMadeRight;
        WrapPoint.OnToyMadeWrong -= UpdatePartsWasted;
        Trash.OnPartThrown -= UpdatePartsWasted;
    }
}
