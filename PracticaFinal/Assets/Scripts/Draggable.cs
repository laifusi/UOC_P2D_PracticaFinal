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

    public void DropItem(ItemSO item)
    {
        if (droppable)
        {
            dropPoint.ItemDropped(item);
        }

        Destroy(gameObject);
    }

    public void DropToy(ToyObject toy)
    {
        if(droppable)
        {
            dropPoint.ToyDropped(toy);
        }
        else
        {
            toy.ReturnToLastPoint();
        }
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
