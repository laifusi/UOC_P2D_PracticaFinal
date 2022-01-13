using UnityEngine;

public abstract class DropPoint : MonoBehaviour
{
    [SerializeField] protected bool acceptsItems; //bool to define if the DropPoint accepts items
    [SerializeField] protected bool acceptsToys; //bool to define if the DropPoint accepts toys

    /// <summary>
    /// OnTriggerEnter2D to check if we collided with an item or a toy
    /// If we did, we check if we accept it and se the droppable and the DropPoint variables of the Draggable
    /// </summary>
    /// <param name="collision">Collider2D that triggered us</param>
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

    /// <summary>
    /// OnTriggerExit2D method to determine if a Draggable is no longer over us
    /// </summary>
    /// <param name="collision">Collider2D that triggered us</param>
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

    /// <summary>
    /// Abstract method to define what to do when an item is dropped on us
    /// </summary>
    /// <param name="item">Dropped item</param>
    public abstract void ItemDropped(ItemSO item);

    /// <summary>
    /// Abstract method to define what to do when a toy is dropped on us
    /// </summary>
    /// <param name="toy">Dropped toy</param>
    public abstract void ToyDropped(ToyObject toy);
}
