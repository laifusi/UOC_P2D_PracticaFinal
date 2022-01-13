using System;
using UnityEngine;

public class Trash : DropPoint
{
    private int partsThrown; //number of parts thrown
    private SpriteRenderer spriteRenderer; //SpriteRenderer component
    private AudioSource audioSource; //AudioSource component

    public static Action<int> OnPartThrown; //Action to call when a part is thrown

    [SerializeField] private Sprite[] trashSprites; //Sprites for the trash, change every 5 item thrown
    [SerializeField] private ToyMachine toyMachine; //ToyMachine

    /// <summary>
    /// Start method to initialize components
    /// </summary>
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Method to define the behaviour when an item is dropped over us
    /// We play the sound effect and update the number of thrown parts
    /// </summary>
    /// <param name="item">Item thrown</param>
    public override void ItemDropped(ItemSO item)
    {
        audioSource.Play();
        UpdateThrownParts();
        OnPartThrown?.Invoke(1);
    }

    /// <summary>
    /// Method to define the behaviour when a toy is dropped over us
    /// We play a sound effect, update the parts thrown and destroy the toy
    /// </summary>
    /// <param name="toy">ToyObject dropped</param>
    public override void ToyDropped(ToyObject toy)
    {
        audioSource.Play();
        UpdateThrownParts();
        OnPartThrown?.Invoke(toyMachine.createdToy.toyParts.Length);
        Destroy(toy.gameObject);
    }

    /// <summary>
    /// Method to update the number of thrown parts and the trash sprites
    /// </summary>
    private void UpdateThrownParts()
    {
        partsThrown++;
        if (partsThrown >= 25)
        {
            spriteRenderer.sprite = trashSprites[5];
        }
        else if (partsThrown >= 20)
        {
            spriteRenderer.sprite = trashSprites[4];
        }
        else if (partsThrown >= 15)
        {
            spriteRenderer.sprite = trashSprites[3];
        }
        else if (partsThrown >= 10)
        {
            spriteRenderer.sprite = trashSprites[2];
        }
        else if (partsThrown >= 5)
        {
            spriteRenderer.sprite = trashSprites[1];
        }
        else
        {
            spriteRenderer.sprite = trashSprites[0];
        }
    }
}
