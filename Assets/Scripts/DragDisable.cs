using UnityEngine;
using UnityEngine.EventSystems;

public class DragDisable : MonoBehaviour, IPointerEnterHandler ,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        DragAndDrop.Instance.StopDrag();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DragAndDrop.Instance._raycast = true;     
    }
}
