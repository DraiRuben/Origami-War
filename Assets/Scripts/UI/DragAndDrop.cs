using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    public bool _raycast = true;
    private Vector3 _dragPosition;

    private void Update()
    {
        if(_raycast)
            CheckObject();    
    }

    private void CheckObject()
    {
        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        Physics.Raycast(ray, out var hit);
        
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
        
        Debug.DrawRay(Mouse.current.position.ReadValue(), Camera.main.transform.forward, Color.yellow);
    }
}
