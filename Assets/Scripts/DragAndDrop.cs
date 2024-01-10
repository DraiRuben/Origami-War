using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    public bool _raycast = true;
    private Vector3 _dragPosition;
    private GameObject _dragTower;
    public bool _canDrop;
    
    public static DragAndDrop Instance;
    
    public List<GameObject> _collision = new List<GameObject>();

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
        if (_dragTower != null)
        {
            _dragTower.transform.position = _dragPosition;
            HighlightTower(); 
        }
        
        DetecteCollisionWithOtherObject();
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

    private void HighlightTower()
    {
        if (_canDrop)
        {
            _dragTower.transform.GetChild(0).gameObject.SetActive(true);   
            _dragTower.transform.GetChild(1).gameObject.SetActive(false);    
        }
        else 
        {
            _dragTower.transform.GetChild(0).gameObject.SetActive(false);
            _dragTower.transform.GetChild(1).gameObject.SetActive(true);     
        }
    }

    private void DetecteCollisionWithOtherObject()
    {
        if (_collision.Count == 0)
            _canDrop = true;
        else
            _canDrop = false;
    }

    private void CheckObject()
    {
        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        Physics.Raycast(ray, out var hit);

        if (hit.collider != null)
        {
            _dragPosition = hit.point;

            if (hit.transform.gameObject.tag == "NotPlaceableOn")
                _canDrop = false;
            else if (hit.transform.gameObject.tag == "PlaceableOn") 
                _canDrop = true;
        }
        Debug.DrawRay(Mouse.current.position.ReadValue(), Camera.main.transform.forward, Color.yellow);
    }
}
