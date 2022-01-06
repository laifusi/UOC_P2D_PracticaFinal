using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool droppable;

    public void SetDroppable(bool canBeDropped)
    {
        droppable = canBeDropped;
    }

    public void Drop()
    {
        if(!droppable)
        {
            Destroy(gameObject);
        }
    }
}
