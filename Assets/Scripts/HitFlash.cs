using UnityEngine;
using System.Collections;

public class HitFlash : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    private Material normalMaterial;
    private SpriteRenderer spriteRenderer;
    private Health health;
    private Coroutine flashRoutine;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        normalMaterial = spriteRenderer.material;
        health = GetComponent<Health>();
        flashRoutine = null;
    }


    private IEnumerator Flash()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.1f);

        spriteRenderer.material = normalMaterial;
    }

    void OnEnable()
    {
        spriteRenderer.material = normalMaterial;
        health.OnHit += HandleHit;
    }

    void OnDisable()
    {
        health.OnHit -= HandleHit;
    }

    private void HandleHit()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(Flash()); 
    }
}
