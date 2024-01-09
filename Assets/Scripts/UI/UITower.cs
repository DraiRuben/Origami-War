using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UITower : MonoBehaviour
{
    [SerializeField] GameObject _tower;

    public void SelectedTower()
    {
        Instantiate(_tower, transform.position, Quaternion.identity);
    }
}
