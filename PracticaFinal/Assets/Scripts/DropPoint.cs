using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropPoint : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Draggable item = collision.GetComponent<Draggable>();
        if (item != null)
        {
            item.SetDroppable(true);
            item.SetDropPoint(this);
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        Draggable item = collision.GetComponent<Draggable>();
        if(item != null)
        {
            item.SetDroppable(false);
        }
    }

    public abstract void ObjectDropped();
}
