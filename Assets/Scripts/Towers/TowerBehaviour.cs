using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField] private TowersStats Stats;
    private List<EnemyStats> EnemiesInRange;
    private void Awake()
    {
        EnemiesInRange = new List<EnemyStats>();
    }
    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }
    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (GameState.Instance.IsWaveRunning)
            {

            }
            yield return null;
        }
    }
}
