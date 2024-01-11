using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower")]
public class TowersStats : ScriptableObject
{
    public uint Damage;
    public float FireRate;
    public float Range;

    public bool SlowEnemies;
    [ShowIf(nameof(SlowEnemies))]
    [Range(0,1f)]
    public float SlowMultiplier;
    [ShowIf(nameof(SlowEnemies))]
    [MinValue(0.1f)]
    public float SlowDuration;

    public bool InflictDOT;
    [ShowIf(nameof(InflictDOT))]
    public uint DOT;
    [ShowIf(nameof(InflictDOT))]
    [MinValue(.1f)]
    public float DOTDuration;
    [ShowIf(nameof(InflictDOT))]
    [MinValue(.01f)]
    public float DOTInterval;
}
