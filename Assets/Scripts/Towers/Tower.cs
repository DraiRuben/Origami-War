using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowersStats _towersStats;

    [HideInInspector] public float _damage;
    [HideInInspector] public float _fireRate;

    private void Awake()
    {
        _damage = _towersStats._damage;
        _fireRate = _towersStats._fireRate;
    }
}
