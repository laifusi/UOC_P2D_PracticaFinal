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
        if(MouseControl.Instance.DetectClicks)
        {
            item = Instantiate(prefab, MouseControl.Instance.GetMousePosition(), Quaternion.identity).transform;
            item.GetComponent<Draggable>().SetSprite(itemSO.sprite);
            item.gameObject.AddComponent<PolygonCollider2D>();
        }
    }

    private void OnMouseDrag()
    {
        if(MouseControl.Instance.DetectClicks && item != null)
            item.position = MouseControl.Instance.GetMousePosition();
    }


    private void OnMouseUp()
    {
        if(MouseControl.Instance.DetectClicks && item != null)
            item.GetComponent<Draggable>().DropItem(itemSO);
    }
}
