using TMPro;
using UnityEngine;

public class PlaceTowerInteraction : MonoBehaviour
{
    public GameObject TowerInformation;
    public bool _isPlaced;

    [Header("Texts")] 
    [SerializeField] private TMP_Text Desc;
    [SerializeField] private TMP_Text SalesGain;
    private void OnMouseUp()
    {
        if (_isPlaced)
        {
            TowerInformation.SetActive(true);
            Desc.SetText(GetComponent<TowerBehaviour>().Stats.Desc);
            SalesGain.SetText((GetComponent<TowerBehaviour>().Stats.Cost/2).ToString());
            transform.GetChild(0).gameObject.SetActive(true);
            InputManager.Instance.SelectedTower = this.gameObject;
        }
    }
}