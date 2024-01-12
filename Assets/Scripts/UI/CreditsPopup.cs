using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject Popup;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Popup.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Popup.SetActive(false);
    }
}
