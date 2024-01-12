using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

public class UnlockSecondPath : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;
    [SerializeField] private int TriggerWave;
    private void Start()
    {
        GameState.Instance.OnWaveChanged += TryDestroyBuilding;
    }
    public void TryDestroyBuilding(int NewWave)
    {
        if (NewWave == TriggerWave)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
