using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Transform item;

    [SerializeField] GameObject prefab;

    private void OnMouseDown()
    {
        item = Instantiate(prefab, MouseControl.Instance.GetMousePosition(), Quaternion.identity).transform;
    }

    private void OnMouseDrag()
    {
        item.position = MouseControl.Instance.GetMousePosition();
    }


    private void OnMouseUp()
    {
        item.GetComponent<Draggable>().Drop();
    }
}
