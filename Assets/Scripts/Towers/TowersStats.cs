using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower")]
public class TowersStats : ScriptableObject
{
    public int Damage;
    public float FireRate;
    public float Range;
    public int Cost;
    public bool AttackOnceEach;
    public GameObject Projectile;
    [MinValue(.001f)]
    public float ProjectileSpeed;

    public string Desc;

    public bool InflictSlow;
    [ShowIf(nameof(InflictSlow))]
    [Range(0,1f)]
    public float SlowMultiplier;
    [ShowIf(nameof(InflictSlow))]
    [MinValue(0.1f)]
    public float SlowDuration;

    public bool InflictDOT;
    [ShowIf(nameof(InflictDOT))]
    public int DOT;
    [ShowIf(nameof(InflictDOT))]
    [MinValue(.1f)]
    public float DOTDuration;
    [ShowIf(nameof(InflictDOT))]
    [MinValue(.01f)]
    public float DOTInterval;
}
