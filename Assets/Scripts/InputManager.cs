using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject SelectedTower;
    public bool _HideUI = true;

    public static InputManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Drop(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (DragAndDrop.Instance._raycast && DragAndDrop.Instance._canDrop)
            {
                DragAndDrop.Instance.Drop();
            }
            else if (_HideUI)
            {
                UITowerInformation.Instance.gameObject.SetActive(false);
                if (SelectedTower != null)
                {
                    SelectedTower.transform.GetChild(0).gameObject.SetActive(false);
                    SelectedTower.transform.GetChild(2).gameObject.SetActive(false);
                }
                SelectedTower = null;
            }
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
                
                UIManager.Instance._starWaveButton.GetComponent<Button>().interactable = true;
                UIManager.Instance._starWaveButton.GetComponent<Image>().color = new Color32(16, 217, 207, 255);
            }
            else
            {
                if (DragAndDrop.Instance._dragTower != null)
                    Destroy(DragAndDrop.Instance._dragTower);

                Time.timeScale = 0;
                UIManager.Instance._pauseButtons.GetComponent<Button>().interactable = false;
                UIManager.Instance._pauseButtons.GetComponent<Image>().color = Color.white;
                
                UIManager.Instance._starWaveButton.GetComponent<Button>().interactable = false;
                UIManager.Instance._starWaveButton.GetComponent<Image>().color = Color.white;
                
                UITowerInformation.Instance.gameObject.SetActive(false);
                if (SelectedTower != null)
                {
                    SelectedTower.transform.GetChild(0).gameObject.SetActive(false);
                    SelectedTower.transform.GetChild(2).gameObject.SetActive(false);
                }
                SelectedTower = null;
            }
        }
        else if (context.started && UIManager.Instance._settingsMenu.activeSelf)
        {
            UIManager.Instance._pauseMenu.SetActive(!UIManager.Instance._pauseMenu.activeSelf);
            UIManager.Instance._settingsMenu.SetActive(!UIManager.Instance._settingsMenu.activeSelf);
        }
    }

    public void Cancel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DragAndDrop.Instance.StopDrag();
        }
    }
}
