using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int MaxHealth;
    private int currentHealth;
    public int RewardMoney;

    public float MovementSpeed;
    public float DetectionRadius;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; if (value <= 0) { GameState.Instance.Cash += RewardMoney; Destroy(gameObject); } }
    }


    private float SlowRemainingDuration;
    private Coroutine m_slowRoutine;

    private void Awake()
    {
        currentHealth = MaxHealth;
    }
    public void TakeDOT(int DOT, float Duration, float Interval)
    {
        StartCoroutine(ApplyDOT(DOT, Duration, Interval));
    }
    public void TakeSlow(float Multiplier, float Duration)
    {
        SlowRemainingDuration = Duration;
        m_slowRoutine ??= StartCoroutine(ApplySlow(Multiplier));
    }
    private IEnumerator ApplyDOT(int DOT, float Duration, float Interval)
    {
        float currentTime = 0f;
        while (currentTime < Duration)
        {
            CurrentHealth -= DOT;
            currentTime += Interval;
            yield return new WaitForSeconds(Interval);
        }
    }
    private IEnumerator ApplySlow(float Multiplier)
    {
        float OriginalSpeed = MovementSpeed;

        MovementSpeed *= Multiplier;
        while (SlowRemainingDuration > 0)
        {
            SlowRemainingDuration -= Time.deltaTime;
            yield return null;
        }
        MovementSpeed = OriginalSpeed;
    }
}
