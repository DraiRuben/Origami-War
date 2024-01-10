using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UITower : MonoBehaviour
{
    [SerializeField] private GameObject _tower;

    public void SelectTower()
    {
        DragAndDrop.Instance.BeginDrag(_tower);
    }
}
