using UnityEngine;

public class Box : MonoBehaviour
{
    private Transform item; //Transform for the item we take from the box

    [SerializeField] GameObject prefab; //Prefab of the item
    [SerializeField] ItemSO itemSO; //ItemSO of the item to take

    /// <summary>
    /// Method to control the mouse clicks over the box
    /// If we should be detecting clicks, we instantiate the item
    /// </summary>
    private void OnMouseDown()
    {
        if(MouseControl.Instance.DetectClicks)
        {
            item = Instantiate(prefab, MouseControl.Instance.GetMousePosition(), Quaternion.identity).transform;
            item.GetComponent<Draggable>().SetSprite(itemSO.sprite);
            item.gameObject.AddComponent<PolygonCollider2D>();
        }
    }

    /// <summary>
    /// Method to control the mouse drags initialized on the box
    /// If we should be detecting clicks we update the item's position with the mouse
    /// </summary>
    private void OnMouseDrag()
    {
        if(MouseControl.Instance.DetectClicks && item != null)
            item.position = MouseControl.Instance.GetMousePosition();
    }

    /// <summary>
    /// Method to control the mouse releases
    /// If we should be detecting clicks and we have an item, we Drop the item
    /// </summary>
    private void OnMouseUp()
    {
        if(MouseControl.Instance.DetectClicks && item != null)
            item.GetComponent<Draggable>().DropItem(itemSO);
    }
}
