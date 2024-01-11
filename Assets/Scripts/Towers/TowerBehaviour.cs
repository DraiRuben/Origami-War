using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public TowersStats Stats;
    private List<EnemyStats> EnemiesInRange;
    private void Awake()
    {
        EnemiesInRange = new List<EnemyStats>();
    }
    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }
    private void Update()
    {
        if (GameState.Instance.IsWaveRunning)
        {
            PopulateAttackableEnemies();
        }
    }

    [Button]
    private void WinMoney()
    {
        GameState.Instance.Cash += EnemiesInRange[0].RewardMoney;
    }
    
    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (GameState.Instance.IsWaveRunning)
            {
                if(EnemiesInRange.Count > 0)
                {
                    Debug.Log("Attacked");
                    yield return new WaitForSeconds(1f/Stats.FireRate);
                }

            }
            yield return null;
        }
    }
    private void PopulateAttackableEnemies()
    {
        var Paths = GameState.Instance.Paths;
        for(int i = 0;i<Paths.Count;i++)
        {
            for(int u = 0; u < Paths[i].EnemiesOnPath.Count;u++)
            {
                var Enemy = Paths[i].EnemiesOnPath[u].Object;
                bool IsAlreadyDetected= EnemiesInRange.Contains(Enemy);
                var Pos1 = new Vector2(Enemy.transform.position.x, Enemy.transform.position.z);
                var Pos2 = new Vector2(transform.position.x, transform.position.z);

                //if this is newly detected, add to list of enemies in range
                if (Vector2.Distance(Pos1, Pos2) < Enemy.DetectionRadius*Enemy.transform.localScale.x + Stats.Range*transform.localScale.x)
                {
                    if (!IsAlreadyDetected)
                    {
                        EnemiesInRange.Add(Enemy);
                    }
                }
                //else if we are out of range but the enemy is in the list, remove it from the list of enemies in range
                else if (IsAlreadyDetected)
                {
                    EnemiesInRange.Remove(Enemy);
                }
            }
        }
    }
}
