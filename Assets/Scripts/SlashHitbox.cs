using UnityEngine;

public class SlashHitbox : MonoBehaviour
{
    [SerializeField] private int slashDamage = 10;

    public void OnTriggerEnter2D(Collider2D other)
    {
        // TryGetComponent returns a bool and hands back the component through the out parameter, so I can test-and-grab in one call
        if (other.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(slashDamage);
        }
    }
}