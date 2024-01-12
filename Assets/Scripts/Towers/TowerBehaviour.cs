using Sirenix.OdinInspector;
using System;
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
                EnemiesInRange.RemoveAll(x => x == null);
                if(EnemiesInRange.Count > 0)
                {
                    StartCoroutine(DamageEnemy(EnemiesInRange[0]));
                    if (Stats.AttackOnceEach) EnemiesInRange.RemoveAt(0);
                    yield return new WaitForSeconds(1f/Stats.FireRate);
                }

            }
            yield return null;
        }
    }
    private IEnumerator DamageEnemy(EnemyStats Enemy)
    {
        float distanceWaitTime = FlatDistance(Enemy.transform.position, transform.position) / Stats.ProjectileSpeed;
        StartCoroutine(ProjectileShootRoutine(Enemy.transform.position));
        yield return new WaitForSeconds(distanceWaitTime);
        if (Enemy == null) yield break;

        Enemy.CurrentHealth -= Stats.Damage;
        if (Stats.InflictDOT)
        {
            Enemy.TakeDOT(Stats.DOT, Stats.DOTDuration, Stats.DOTInterval);
        }
        if (Stats.InflictSlow)
        {
            Enemy.TakeSlow(Stats.SlowMultiplier, Stats.SlowDuration);
        }
    }
    private IEnumerator ProjectileShootRoutine(Vector3 Destination)
    {
        float coef = 0;
        Transform Projectile = Instantiate(Stats.Projectile,transform.position,Quaternion.identity).transform;
        Vector3 OriginalPos = Projectile.position;
        float Duration = FlatDistance(Destination, transform.position) / Stats.ProjectileSpeed;
        while (coef < 1)
        {
            coef = Mathf.Clamp01(coef);
            Projectile.position = Vector3.Lerp(OriginalPos, Destination, coef);
            coef += Time.fixedDeltaTime / Duration;
            yield return new WaitForFixedUpdate();
        }
        //I know this isn't very clean but I don't have time for a pooling system
        //I apologize in advance to the garbage collector
        Destroy(Projectile.gameObject);
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
                //if this is newly detected, add to list of enemies in range
                if (FlatDistance(Enemy.transform.position,transform.position) < Enemy.DetectionRadius*Enemy.transform.localScale.x + Stats.Range*transform.localScale.x)
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
    public static float FlatDistance(Vector3 pos1, Vector3 pos2)
    {
        pos1.y = pos1.z;
        pos2.y = pos2.z;
        return Vector2.Distance(pos1, pos2);
    }
}
