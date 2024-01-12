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
        if (GameState.Instance.CurrentWave < GameState.Instance.LastWave)
        {
            gameObject.SetActive(true);
        }
        else
        {
            //EndGame.Instance.gameObject.SetActive(true);
        }
    }
    public void NextWave()
    {
        GameState.Instance.CurrentWave++;
        gameObject.SetActive(false);
    }
}
