using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    public float MovementSpeed;
    public float DetectionRadius;
    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }
}
