using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropPoint : MonoBehaviour
{
    [SerializeField] protected bool acceptsItems;
    [SerializeField] protected bool acceptsToys;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Draggable item = collision.GetComponent<Draggable>();
        ToyObject toy = collision.GetComponent<ToyObject>();
        if(toy == null)
        {
            if (item != null && acceptsItems)
            {
                item.SetDroppable(true);
                item.SetDropPoint(this);
            }
        }
        else if(acceptsToys)
        {
            item.SetDroppable(true);
            item.SetDropPoint(this);
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        Draggable item = collision.GetComponent<Draggable>();
        ToyObject toy = collision.GetComponent<ToyObject>();
        if(toy == null)
        {
            if (item != null && acceptsItems)
            {
                item.SetDroppable(false);
            }
        }
        else if(acceptsToys)
        {
            item.SetDroppable(false);
        }
    }

    public abstract void ItemDropped(ItemSO item);

    public abstract void ToyDropped(ToyObject toy);
}
