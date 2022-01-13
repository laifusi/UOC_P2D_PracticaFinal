using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersBox : MonoBehaviour
{
    private int lettersLeft = 14; //Number of letters left to open
    private SpriteRenderer spriteRenderer; //SpriteRenderer component

    [SerializeField] private Sprite[] letterBoxSprites; //Sprites of the letters box, updates every time we take one
    [SerializeField] private Letter letter; //Letter object
    [SerializeField] private GameManager gameManager; //GameManager to call when there's no letters left

    /// <summary>
    /// Method to initialize components and open the first letter
    /// </summary>
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TakeLetter();
    }

    /// <summary>
    /// Method to open a new letter
    /// If there's no letters left we call the GameManager and win the game
    /// </summary>
    public void TakeLetter()
    {
        lettersLeft--;
        if(lettersLeft < 0)
        {
            gameManager.EndGame();
        }
        else
        {
            StartCoroutine(UpdateSprite());
        }
    }

    /// <summary>
    /// Coroutine to wait a second before opening a letter
    /// We update the box's sprite and call Letter to create a new toy
    /// We show the letter and deactivate detection of clicks until the player closes the letter
    /// </summary>
    private IEnumerator UpdateSprite()
    {
        yield return new WaitForSeconds(1);
        if (lettersLeft >= 0)
            spriteRenderer.sprite = letterBoxSprites[letterBoxSprites.Length - 1 - lettersLeft];
        letter.OpenNewLetter();
        letter.gameObject.SetActive(true);
        MouseControl.Instance.DetectClicks = false;
    }
}
