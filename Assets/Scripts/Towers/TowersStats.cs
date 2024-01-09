using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower")]
public class TowersStats : ScriptableObject
{
    public float _damage;
    public float _fireRate;
    public GameObject _towers;
}
