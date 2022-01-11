using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Transform item;

    [SerializeField] GameObject prefab;
    [SerializeField] ItemSO itemSO;

    private void Start()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sprite = itemSO.sprite;
        }
    }

    private void OnMouseDown()
    {
        item = Instantiate(prefab, MouseControl.Instance.GetMousePosition(), Quaternion.identity).transform;
        item.GetComponent<Draggable>().SetSprite(itemSO.sprite);
    }

    private void OnMouseDrag()
    {
        item.position = MouseControl.Instance.GetMousePosition();
    }


    private void OnMouseUp()
    {
        item.GetComponent<Draggable>().Drop();
    }
}
