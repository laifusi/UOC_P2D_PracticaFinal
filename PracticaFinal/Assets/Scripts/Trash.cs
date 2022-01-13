using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : DropPoint
{
    private int partsThrown;
    private SpriteRenderer spriteRenderer;

    public static Action<int> OnPartThrown;

    [SerializeField] private Sprite[] trashSprites;
    [SerializeField] private ToyMachine toyMachine;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void ItemDropped(ItemSO item)
    {
        UpdateThrownParts();
        OnPartThrown?.Invoke(1);
    }

    public override void ToyDropped(ToyObject toy)
    {
        UpdateThrownParts();
        OnPartThrown?.Invoke(toyMachine.createdToy.toyParts.Length);
        Destroy(toy.gameObject);
    }

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
