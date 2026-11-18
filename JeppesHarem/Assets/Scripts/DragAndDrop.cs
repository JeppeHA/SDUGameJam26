using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DragAndDrop : MonoBehaviour
{
    public Camera myCam;

    private float startXPos;
    private float startYPos;
    private Vector3 startPos;

    public bool isDragging = false;

    private void Start()
    {
        myCam = Camera.main;
        startPos = transform.position;
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
        StartCoroutine(waitAFrame());
    }

    IEnumerator waitAFrame()
    {
        yield return new WaitForSeconds(0.05f);
        transform.position = startPos;
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