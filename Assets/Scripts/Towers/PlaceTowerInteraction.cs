using Unity.Mathematics;
using UnityEngine;

public class PlaceTowerInteraction : MonoBehaviour
{
    public bool IsPlaced;
    [SerializeField] private GameObject Area;
    private void OnMouseDown()
    {
        if (IsPlaced)
        {
            UITowerInformation.Instance.SetInformations(GetComponent<TowerBehaviour>().Stats);
            transform.GetChild(0).gameObject.SetActive(true);
            InputManager.Instance.SelectedTower = gameObject;
            Instantiate(Area, transform.position + new Vector3(0,1,0), Quaternion.identity);
        }
    }
}