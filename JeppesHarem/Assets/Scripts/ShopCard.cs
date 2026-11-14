using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopCard : MonoBehaviour
{
    private Collider2D _col;

    private Vector3 _startDragPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _col = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        
        _startDragPos = transform.position;
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseUp()
    {
        _col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        _col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out ICardDropArea cardDropArea))
        {
            cardDropArea.OnCardDrop(this);
        }
        else
        {
            transform.position = _startDragPos;
        }
    }

    private Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }
}
