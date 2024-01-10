using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void Drop(InputAction.CallbackContext context)
    {
        if (context.performed && DragAndDrop.Instance._raycast)
        {
            DragAndDrop.Instance.Drop();
        }
    }
}
