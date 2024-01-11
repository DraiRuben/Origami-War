using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UITower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _tower;
    private void Start()
    {
        GameState.Instance.OnMoneyChanged += CheckForAvailability;
    }
    private void CheckForAvailability(int newCash)
    {
        
    }
    public void SelectTower()
    {
        DragAndDrop.Instance.BeginDrag(_tower);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(true);    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
