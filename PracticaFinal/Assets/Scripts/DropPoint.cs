using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Draggable item = collision.GetComponent<Draggable>();
        if (item != null)
        {
            item.SetDroppable(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Draggable item = collision.GetComponent<Draggable>();
        if(item != null)
        {
            item.SetDroppable(false);
        }
    }
}
