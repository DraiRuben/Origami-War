using Unity.Mathematics;
using UnityEngine;

public class PlaceTowerInteraction : MonoBehaviour
{
    public bool IsPlaced;
    private void OnMouseDown()
    {
        if (IsPlaced)
        {
            UITowerInformation.Instance.SetInformations(GetComponent<TowerBehaviour>().Stats);
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            InputManager.Instance.SelectedTower = gameObject;
        }
    }
}