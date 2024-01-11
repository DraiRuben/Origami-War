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
    }
    
    /*--------------------------------------------------BUTTONS--------------------------------------------------*/

    public void Pause()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            _pauseButtons.GetComponent<Button>().interactable = true;
            _pauseButtons.GetComponent<Image>().color = new Color32(16, 217, 207, 255);
        }
        else if (Time.timeScale != 0)
        {
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
