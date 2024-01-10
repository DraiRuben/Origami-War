using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void Drop(InputAction.CallbackContext context)
    {
        if (context.performed && DragAndDrop.Instance._raycast && DragAndDrop.Instance._canDrop)
        {
            DragAndDrop.Instance.Drop();
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        UIManager.Instance._pauseMenu.SetActive(!UIManager.Instance._pauseMenu.activeSelf);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else if (Time.timeScale != 0)
            Time.timeScale = 0;
    }
}
