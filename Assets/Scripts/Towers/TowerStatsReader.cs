using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatsReader : MonoBehaviour
{
    [SerializeField] private TowersStats _towersStats;

    [HideInInspector] public float _damage;
    [HideInInspector] public float _fireRate;
    [HideInInspector] public GameObject _tower;

    private void Awake()
    {
        _damage = _towersStats._damage;
        _fireRate = _towersStats._fireRate;
        _tower = _towersStats._towers;
    }
}
