using UnityEngine;

public class OpenLetter : MonoBehaviour
{
    [SerializeField] private GameObject letter; //GameObject of the visual letter

    /// <summary>
    /// Method to detect te mouse click on the open letter
    /// If we can detect clicks, we activate the letter's GameObject and deactivate detection of clicks
    /// </summary>
    private void OnMouseUp()
    {
        if(MouseControl.Instance.DetectClicks)
        {
            letter.SetActive(true);
            MouseControl.Instance.DetectClicks = false;
        }
    }
}
