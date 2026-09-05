using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    [SerializeField] private ObjectPool slashPool;
    [SerializeField] private Transform playerVis;
    [SerializeField] private float attackInterval = 1.5f;
    [SerializeField] private float offset = 2f;

    private static readonly int attackHash = Animator.StringToHash("attack");

    private float lastAttackTime = -100f;
    private Animator anim;
    private PlayerFlip playerFlip;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerFlip = GetComponentInParent<PlayerFlip>();
    }

    void Update()
    {
        if (Time.time - lastAttackTime > attackInterval)
        {
            anim.SetTrigger(attackHash);
            // gets slash prefab from the slash object pool
            GameObject forwardSlash = slashPool.Get();

            // positions the slash correctly on the correct side depening on what "direction" the playerFlip script determines
            float dir = playerFlip.Facing;
            forwardSlash.transform.position = playerVis.position + new Vector3(offset * dir, 0f, 0f);

            // correctly does the orientation of the slash using the direction it gets from playerFlip script
            Vector3 scale = forwardSlash.transform.localScale;
            scale.x = Mathf.Abs(scale.x) * dir;
            forwardSlash.transform.localScale = scale;

            lastAttackTime = Time.time;
        }
    }
}