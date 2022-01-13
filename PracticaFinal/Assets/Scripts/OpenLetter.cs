using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLetter : MonoBehaviour
{
    [SerializeField] private GameObject letter;

    private void OnMouseUp()
    {
        if(MouseControl.Instance.DetectClicks)
        {
            letter.SetActive(true);
            MouseControl.Instance.DetectClicks = false;
        }
    }
}
