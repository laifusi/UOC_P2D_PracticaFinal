using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position - MouseControl.Instance.GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = MouseControl.Instance.GetMousePosition() + offset;
    }

    private void OnMouseUp()
    {
    }
}
