using UnityEngine;
using System;
public class PlayerDeath : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
        health.OnDied += Die;
    }

    void Die()
    {
        OnPlayerDeath?.Invoke();
    }

    void OnDestroy()
    {
        health.OnDied -= Die;
    }
}
