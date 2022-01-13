using UnityEngine;

public class ToyObject : Draggable
{
    private Vector3 position; //Vector3 that defines the last correct position

    /// <summary>
    /// Start method to initialize the position
    /// </summary>
    private void Start()
    {
        position = transform.position;
    }

    /// <summary>
    /// Method to save a new correct position
    /// </summary>
    /// <param name="newPosition"></param>
    public void SavePosition(Vector3 newPosition)
    {
        position = newPosition;
    }

    /// <summary>
    /// Method to return to the last correct position
    /// </summary>
    public void ReturnToLastPoint()
    {
        transform.position = position;
    }

    /// <summary>
    /// Method to move the toy with the mouse, if clicks can be detected
    /// </summary>
    private void OnMouseDrag()
    {
        if (MouseControl.Instance.DetectClicks)
            transform.position = MouseControl.Instance.GetMousePosition();
    }

    /// <summary>
    /// Method to drop the toy
    /// </summary>
    private void OnMouseUp()
    {
        if (MouseControl.Instance.DetectClicks)
            DropToy(this);
    }
}
