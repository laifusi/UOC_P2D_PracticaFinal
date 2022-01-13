using UnityEngine;

public class ToyObject : Draggable
{
    private Vector3 position;
    private Toy toy;

    private void Start()
    {
        position = transform.position;
    }

    public void SavePosition(Vector3 newPosition)
    {
        position = newPosition;
    }

    public void ReturnToLastPoint()
    {
        transform.position = position;
    }

    private void OnMouseDrag()
    {
        if (MouseControl.Instance.DetectClicks)
            transform.position = MouseControl.Instance.GetMousePosition();
    }


    private void OnMouseUp()
    {
        if (MouseControl.Instance.DetectClicks)
            DropToy(this);
    }
}
