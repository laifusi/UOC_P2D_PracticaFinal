using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool droppable; //bool to determine if we can drop the object or not
    private DropPoint dropPoint; //DropPoint that has been detected
    
    /// <summary>
    /// Method to define if we are over a drop point
    /// </summary>
    /// <param name="canBeDropped">whether we can drop or not</param>
    public void SetDroppable(bool canBeDropped)
    {
        droppable = canBeDropped;
    }

    /// <summary>
    /// Method to act when an item is dropped
    /// We check if it's droppable and tell the DropPoint we are droping it
    /// We destroy the item
    /// </summary>
    /// <param name="item">ItemSO we are dropping</param>
    public void DropItem(ItemSO item)
    {
        if (droppable)
        {
            dropPoint.ItemDropped(item);
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// Method to act when a created toy is dropped
    /// We check if it's over a DropPoint and tell it we are dropping the toy
    /// If it can't be dropped, we go back to our last position
    /// </summary>
    /// <param name="toy">ToyObject we are dropping</param>
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

    /// <summary>
    /// Method to set the item's sprite
    /// </summary>
    /// <param name="sprite">Sprite the item should have</param>
    public void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    /// <summary>
    /// Method to save the DropPoint we are over
    /// </summary>
    /// <param name="point">DropPoint we found</param>
    public void SetDropPoint(DropPoint point)
    {
        dropPoint = point;
    }
}
