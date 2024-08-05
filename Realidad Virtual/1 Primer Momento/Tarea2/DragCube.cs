using UnityEngine;

public class DragCube : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = cam.WorldToScreenPoint(transform.position).z;

        offset = transform.position - cam.ScreenToWorldPoint(mousePosition);
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = cam.WorldToScreenPoint(transform.position).z;

        transform.position = cam.ScreenToWorldPoint(mousePosition) + offset;
    }
}
