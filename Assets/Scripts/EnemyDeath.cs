using UnityEngine;
using System;

public class EnemyDeath : MonoBehaviour
{
    public static event Action OnEnemyDeath;
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
    }

    void OnEnable()
    {
        health.OnDied += Die;
    }

    void OnDisable()
    {
        health.OnDied -= Die;
    }

    private void Die()
    {
        OnEnemyDeath?.Invoke();
        GetComponent<PooledObject>().ReturnToPool();
    }
}