using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    public bool _raycast = true;
    private Vector3 _dragPosition;
    private GameObject _dragTower;
    
    public static DragAndDrop Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if(_raycast)
            CheckObject();  
        if(_dragTower != null)
            _dragTower.transform.position = _dragPosition;
    }

    public void BeginDrag(GameObject newTower)
    { 
        CheckObject();
        _dragTower = Instantiate(newTower, _dragPosition, Quaternion.identity);
    }

    public void StopDrag()
    { 
        _raycast = false;
        Destroy(_dragTower);
    }

    public void Drop()
    {
        _raycast = false;
        _dragTower.transform.position = _dragPosition;
        _dragTower = null;
    }

    private void CheckObject()
    {
        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        Physics.Raycast(ray, out var hit);

        if (hit.collider != null)
        {
            _dragPosition = hit.point;
        }
        Debug.DrawRay(Mouse.current.position.ReadValue(), Camera.main.transform.forward, Color.yellow);
    }
}
