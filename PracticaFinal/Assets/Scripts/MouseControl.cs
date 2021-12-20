using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    private Vector3 mousePos;
    private float zOffset;

    public static MouseControl Instance;

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
    }

    public Vector3 GetMousePosition()
    {
        mousePos = Input.mousePosition;
        mousePos.z += zOffset;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
