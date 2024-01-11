using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
        if (context.started && !UIManager.Instance._settingsMenu.activeSelf)
        {
            UIManager.Instance._pauseMenu.SetActive(!UIManager.Instance._pauseMenu.activeSelf);
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                UIManager.Instance._pauseButtons.GetComponent<Button>().interactable = true;
                UIManager.Instance._pauseButtons.GetComponent<Image>().color = new Color32(16, 217, 207, 255);
            }
            else
            {
                if (DragAndDrop.Instance._dragTower != null)
                    Destroy(DragAndDrop.Instance._dragTower);
                
                Time.timeScale = 0;
                UIManager.Instance._pauseButtons.GetComponent<Button>().interactable = false;
                UIManager.Instance._pauseButtons.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            } 
        }
        else if (context.started && UIManager.Instance._settingsMenu.activeSelf)
        {
            UIManager.Instance._pauseMenu.SetActive(!UIManager.Instance._pauseMenu.activeSelf);    
            UIManager.Instance._settingsMenu.SetActive(!UIManager.Instance._settingsMenu.activeSelf);   
        }
    }
}
