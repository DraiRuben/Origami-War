using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public int CurrentWave;
    public int LastWave;
    [SerializeField] private int _cash;
    public int Cash { get { return _cash; } set { _cash = value; OnMoneyChanged.Invoke(value); } }

    public event Action<int> OnMoneyChanged;
    public int CurrentHealth;
    public int InitialHealth;
    public bool IsWaveRunning;

    public List<EnemyPathManager> Paths;
    [Button]
    private void GoToNextWaveDebug()
    {
        OnWaveChanged.Invoke(CurrentWave);
        IsWaveRunning = true;
        UIManager.Instance._currentWave.SetText(CurrentWave.ToString());
    }

    [Button]
    private void WinMoney()
    {
        Cash += 5;
    }

    [Button]
    private void LostMoney()
    {
        Cash -= 5;
    }
    
    //Invoked when the player finishes the current wave and has the auto start next round enabled
    //or if the player clicked on the start next round button with the toggle disabled
    //or at the start of a new game, of course
    public event Action<int> OnWaveChanged;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        CurrentHealth = InitialHealth;
        Paths = new List<EnemyPathManager>();
    }
    private void Start()
    {
        Cash = _cash;
    }
}
