using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceTowerInteraction : MonoBehaviour
{
    public GameObject TowerInformation;

    private void OnMouseUp()
    {
        var posInUI = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, -100f, 0);
        Instantiate(TowerInformation, posInUI, Quaternion.identity, GameObject.Find("/Canvas/Tower Information").transform);
    }
}