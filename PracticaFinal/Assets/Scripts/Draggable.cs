using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool droppable;
    private DropPoint dropPoint;

    public void SetDroppable(bool canBeDropped)
    {
        droppable = canBeDropped;
    }

    public void Drop()
    {
        if (droppable)
        {
            dropPoint.ObjectDropped();
        }

        Destroy(gameObject);
    }

    public void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void SetDropPoint(DropPoint point)
    {
        dropPoint = point;
    }
}
