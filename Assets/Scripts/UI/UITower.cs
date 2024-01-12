using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _tower;
    [SerializeField] private Color32 Available;
    [SerializeField] private Color32 Unavailable;
    private bool _canUse;

    private void Start()
    {
        GameState.Instance.OnMoneyChanged += CheckForAvailability;
    }

    private void CheckForAvailability(int newCash)
    {
        if (newCash < _tower.GetComponent<TowerBehaviour>().Stats.Cost)
        {
            GetComponent<Image>().color = Unavailable;
            _canUse = false;
        }
        else
        {
            GetComponent<Image>().color = Available;
            _canUse = true;
        }
    }

    public void SelectTower()
    {
        if (_canUse)
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