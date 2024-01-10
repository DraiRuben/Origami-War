using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text _life;
    public TMP_Text _cash;
    public TMP_Text _currentWave;
    public TMP_Text _maxWave;

    public GameObject _pauseMenu;
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
            Time.timeScale = 1;
        else if (Time.timeScale != 0)
            Time.timeScale = 0;
    }
}
