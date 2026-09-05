using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float knockbackForce = 8f;

    private static readonly int IsMovingHash = Animator.StringToHash("isMoving");

    private bool isKnockedback;
    private Coroutine knockbackCoroutine;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform target;
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private IEnumerator KnockbackTimer()
    {
        yield return new WaitForSeconds(0.2f);

        isKnockedback = false;
    }

    void FixedUpdate()
    {
        if (isKnockedback) return;

        rb.linearVelocity = (target.position - transform.position).normalized * moveSpeed;

        bool isMoving = rb.linearVelocity != Vector2.zero;
        anim.SetBool(IsMovingHash, isMoving);

    }

    void OnEnable()
    {
        rb.linearVelocity = Vector2.zero;
        isKnockedback = false;
        health.OnHit += Knockedback;
    }

    void OnDisable()
    {
        health.OnHit -= Knockedback;
    }

    private void Knockedback()
    {
        isKnockedback = true;
        rb.linearVelocity = (transform.position - target.position).normalized * knockbackForce;
        if (knockbackCoroutine != null)
        {
            StopCoroutine(knockbackCoroutine);
        }

        knockbackCoroutine = StartCoroutine(KnockbackTimer());
    }

    public void Initialize(Transform newTarget)
    {
        target = newTarget;
    }
}