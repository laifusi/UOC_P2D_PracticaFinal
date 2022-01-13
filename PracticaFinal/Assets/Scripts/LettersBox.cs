using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersBox : MonoBehaviour
{
    private int lettersLeft = 14;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite[] letterBoxSprites;
    [SerializeField] private Letter letter;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
