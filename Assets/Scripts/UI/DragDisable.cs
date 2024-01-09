using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDisable : MonoBehaviour, IPointerEnterHandler ,IPointerExitHandler
{
    [SerializeField] private DragAndDrop _dragAndDrop;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        _dragAndDrop._raycast = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _dragAndDrop._raycast = true;     
    }
}
