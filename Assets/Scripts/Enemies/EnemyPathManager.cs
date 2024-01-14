using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPathManager : MonoBehaviour
{
    public List<Enemy> EnemiesOnPath;

    private List<Vector3> m_pathPositions;
    private void Awake()
    {
        EnemiesOnPath = new();

        LineRenderer LR = GetComponent<LineRenderer>();
        Vector3[] Positions = new Vector3[LR.positionCount];
        LR.GetPositions(Positions);
        m_pathPositions = Positions.ToList();
    }
    private void Start()
    {
        GameState.Instance.Paths.Add(this);
    }
    public void AddEnemyToManager(EnemyStats toManage)
    {
        EnemiesOnPath.Add(new Enemy(toManage));
    }
    [Serializable]
    public class Enemy
    {
        public EnemyStats Object;
        public float MoveCoef;
        public int CurrentPathIndex;
        public Enemy(EnemyStats _Object)
        {
            Object = _Object;
            MoveCoef = 0;
            CurrentPathIndex = 0;
        }
    }
    private void Update()
    {
        if (EnemiesOnPath != null && EnemiesOnPath.Count > 0)
        {
            for (int i = 0; i < EnemiesOnPath.Count; i++)
            {
                Enemy currentEnemy = EnemiesOnPath[i];
                if (currentEnemy.Object == null)
                {
                    EnemiesOnPath[i] = null;
                    continue;
                }
                if (currentEnemy.MoveCoef >= 1f)
                {
                    currentEnemy.MoveCoef = 0;
                    currentEnemy.CurrentPathIndex++;
                    if (currentEnemy.CurrentPathIndex + 1 >= m_pathPositions.Count)
                    {
                        //inflict damage since enemy arrived at the end of its path
                        GameState.Instance.CurrentHealth -= currentEnemy.Object.MaxHealth;
                        UIManager.Instance._life.SetText(GameState.Instance.CurrentHealth.ToString());
                        Endgame.Instance.GameOver();
                        currentEnemy.Object.CurrentHealth = 0;
                        EnemiesOnPath[i] = null;
                        continue;
                    }
                }
                Vector3 OriginPoint = m_pathPositions[currentEnemy.CurrentPathIndex];
                Vector3 EndPoint = m_pathPositions[currentEnemy.CurrentPathIndex + 1];
                currentEnemy.MoveCoef += Time.deltaTime / Vector3.Distance(OriginPoint, EndPoint) * currentEnemy.Object.MovementSpeed;

                Vector3 NewPos = Vector3.Lerp(OriginPoint, EndPoint, currentEnemy.MoveCoef);
                NewPos.Set(NewPos.x, currentEnemy.Object.transform.position.y, NewPos.z);
                currentEnemy.Object.transform.position = NewPos;
            }

            EnemiesOnPath.RemoveAll(x => x == null);
        }
    }
}
