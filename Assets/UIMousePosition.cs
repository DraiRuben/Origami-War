using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMousePosition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        InputManager.Instance._HideUI = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InputManager.Instance._HideUI = true;    
    }
}
