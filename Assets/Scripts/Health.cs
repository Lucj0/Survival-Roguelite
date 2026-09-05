using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action OnDied;
    public event Action OnHit;
    public event Action<int, int> OnHealthChanged;

    [SerializeField] private int maxHealth;
    public int MaxHealth => maxHealth;

    private bool isDead;

    private int currentHealth;

    public int CurrentHealth
    {
        get => currentHealth;
        private set
        {
            currentHealth = value;
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }

    void OnEnable()
    {
        CurrentHealth = maxHealth;
        isDead = false;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        int clampedHealth = Mathf.Max(currentHealth - damage, 0);
        CurrentHealth = clampedHealth;
        OnHit?.Invoke();
        if (CurrentHealth <= 0)
        {
            isDead = true;
            OnDied?.Invoke();
        }
    }
}