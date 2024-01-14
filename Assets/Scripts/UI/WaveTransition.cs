using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTransition : MonoBehaviour
{
    public static WaveTransition Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void EndWave()
    {
        if (GameState.Instance.CurrentWave < GameState.Instance.LastWave - 1)
        {
            if (Switch.Instance.isOn)
            {
                NextWave();
                return;
            }
            GameState.Instance.IsWaveRunning = false;
            gameObject.SetActive(true);
        }
        else
        {
            GameState.Instance.IsWaveRunning = false;
            Endgame.Instance.Win();
        }
    }
    public void NextWave()
    {
        GameState.Instance.CurrentWave++;
        GameState.Instance.IsWaveRunning = true;
        UIManager.Instance._currentWave.SetText((GameState.Instance.CurrentWave + 1).ToString());
        gameObject.SetActive(false);
    }
}
