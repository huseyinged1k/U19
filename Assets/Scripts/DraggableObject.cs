using System;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector2 offset;
    private bool isDragging = false;
    [SerializeField] private Player player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    
    private void OnMouseDown()
    {
        Vector2 objectPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        offset = objectPos - GetMouseWorldPos();
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            player.isTelekinetic = isDragging;
            Vector2 mousePos = GetMouseWorldPos();
            transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        player.isTelekinetic = isDragging;
    }

    private Vector2 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPos;
    }
}
