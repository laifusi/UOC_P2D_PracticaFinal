using UnityEngine;

public class MouseControl : MonoBehaviour
{
    [SerializeField] Camera mainCamera; //Camera

    private Vector3 mousePos; //Vector3 to save the position of the mouse
    private float zOffset; //z offset to the camera

    public static MouseControl Instance; //Instance of the MouseControl

    [HideInInspector] public bool DetectClicks; //bool that defines if clicks should be detected by our drag and drop system

    /// <summary>
    /// Start method to initialize the z offset, the Instance and the detection of clicks
    /// </summary>
    private void Start()
    {
        zOffset = -mainCamera.transform.position.z;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DetectClicks = true;
    }

    /// <summary>
    /// Method that returns the mouse's position as a world point, with the z offset
    /// </summary>
    /// <returns></returns>
    public Vector3 GetMousePosition()
    {
        mousePos = Input.mousePosition;
        mousePos.z += zOffset;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
