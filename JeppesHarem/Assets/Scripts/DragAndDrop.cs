using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DragAndDrop : MonoBehaviour
{
    public Camera myCam;

    private float startXPos;
    private float startYPos;

    public bool isDragging = false;

    private void Start()
    {
        myCam = Camera.main;
    }

    private void Update()
    {
        if (isDragging)
        {
            DragObject();
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.y - transform.localPosition.y;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    public void DragObject()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!myCam.orthographic)
        {
            mousePos.z = 0;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);

        transform.localPosition = new Vector3(mousePos.x - startXPos, mousePos.y - startYPos, transform.localPosition.z);
    }
}