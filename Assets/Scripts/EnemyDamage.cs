using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int enemyDamage = 2;
    [SerializeField] private float damageInterval = 1f;

    private Health playerHealth;
    private float lastHitTime;


    void OnEnable()
    {
        lastHitTime = -100f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            playerHealth = health;
        }
    }

    // this is an unconditional null, but safe for now since enemy can only contact the player. If more descrutible objects/minions, will need to safe-guard
    void OnTriggerExit2D(Collider2D other)
    {
        playerHealth = null;
    }

    void Update()
    {
        if (Time.time - lastHitTime > damageInterval && playerHealth != null)
        {
            playerHealth.TakeDamage(enemyDamage);
            lastHitTime = Time.time;
        }
    }
}
