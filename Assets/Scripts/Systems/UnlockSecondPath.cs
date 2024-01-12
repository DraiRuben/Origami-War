using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

public class UnlockSecondPath : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;
    [Button]
    public void DestroyBuilding()
    {
        if (GameState.Instance.CurrentWave == 0)
        {
            Instantiate(Explosion, transform.position, quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
