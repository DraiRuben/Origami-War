using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Wave> Waves;
    public Queue<SpawnInfo> WaveQueue = new();
    [SerializeField] private EnemyPathManager m_pathManager;

    private static List<EnemySpawner> Spawners;
    private void Awake()
    {
        Spawners ??= new List<EnemySpawner>();

        Spawners.Add(this);
        Spawners.RemoveAll(x => x == null);
    }
    void Start()
    {
        GameState.Instance.OnWaveChanged += QueueWave;
    }
    //called when we start a new wave, it puts all elements to spawn in the wave spawn queue, one by one,
    //then it starts the coroutine that actually instantiates those elements
    private void QueueWave(int Wave)
    {
        if (Waves[Wave].ToSpawn != null)
        {
            for (int i = 0; i < Waves[Wave].ToSpawn.Count; i++)
            {
                WaveQueue.Enqueue(Waves[Wave].ToSpawn[i]);
            }
            if(WaveQueue.Count > 0)
            StartCoroutine(SpawnRoutine());
        }
    }
    private IEnumerator SpawnRoutine()
    {
        //get the amount to spawn
        int RemainingCountToSpawn = WaveQueue.Peek().Amount;
        //tries to spawn things while we still have things to spawn that are in the queue
        while (WaveQueue.Count > 0)
        {
            //decrease the remaining count then instantiates to corresponding element and waits for a certain time
            RemainingCountToSpawn--;
            var NewEnemy = Instantiate(WaveQueue.Peek().ToSpawn, transform.position, WaveQueue.Peek().ToSpawn.transform.rotation);
            var EnemyComp = NewEnemy.GetComponent<EnemyStats>();
            EnemyComp.OnEnemyDeath.AddListener(TryEndWave);

            m_pathManager.AddEnemyToManager(EnemyComp);
            yield return new WaitForSeconds(WaveQueue.Peek().SpawnWaitTime);

            //after waiting we try to see if we need to start spawning the next element, ie: the amount remaining is 0
            if (RemainingCountToSpawn <= 0)
            {
                WaveQueue.Dequeue();
                WaveQueue.TryPeek(out SpawnInfo Info);
                if (Info != null)
                    RemainingCountToSpawn = Info.Amount;
            }

        }
        //do something there to indicate that we finished spawning things,
        //and as such if the player kills everything we spawned and there isn't any other spawners that are still spawning things then the wave can end
        //this is needed since the player could easily just kill everything we throw at him before we finish spawning everything, but we wouldn't want the wave to end before we finished spawning all we need
        yield return null;
    }
    private void TryEndWave()
    {
        var empty = Spawners.All(x => x.WaveQueue.Count <= 0);
        if (EnemyStats.EnemyCount <= 0 && empty)
        {
            WaveTransition.Instance.EndWave();
        }
    }
    [Serializable]
    public struct Wave
    {
        public List<SpawnInfo> ToSpawn;
    }
    [Serializable]
    public class SpawnInfo
    {
        [ValidateInput("@ToSpawn != null")]
        public GameObject ToSpawn;
        [MinValue(1)]
        public int Amount;
        [MinValue(0f)]
        public float SpawnWaitTime;
    }
}
