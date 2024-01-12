using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Texts")]
    public TMP_Text _life;
    public TMP_Text _cash;
    public TMP_Text _currentWave;
    public TMP_Text _maxWave;

    [Header("Menus")]
    public GameObject _pauseMenu;
    public GameObject _settingsMenu;
    public GameObject TowerInformation;

    [Header("Buttons")] 
    public GameObject _pauseButtons;
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _life.SetText(GameState.Instance.InitialHealth.ToString());
        _currentWave.SetText(GameState.Instance.CurrentWave.ToString());
        _maxWave.SetText(GameState.Instance.LastWave.ToString());
        _cash.SetText(GameState.Instance.Cash.ToString());

        GameState.Instance.OnMoneyChanged += SetCashText;
    }

    private void SetCashText(int newCash)
    {
        _cash.SetText(newCash.ToString());
    }
    
    /*--------------------------------------------------BUTTONS--------------------------------------------------*/
    public void Sell()
    {
        if(InputManager.Instance.SelectedTower != null)
            GameState.Instance.Cash += InputManager.Instance.SelectedTower.GetComponent<TowerBehaviour>().Stats.Cost / 2;
        Destroy(InputManager.Instance.SelectedTower);
        TowerInformation.SetActive(false);
    }
    
    public void Pause()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            _pauseButtons.GetComponent<Button>().interactable = true;
            _pauseButtons.GetComponent<Image>().color = new Color32(16, 217, 207, 255);
        }
        else 
        {
            if (DragAndDrop.Instance._dragTower != null)
                Destroy(DragAndDrop.Instance._dragTower);
            
            Time.timeScale = 0;
            _pauseButtons.GetComponent<Button>().interactable = false;
            _pauseButtons.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeSelf);    
        _settingsMenu.SetActive(!_settingsMenu.activeSelf);
    }
}
