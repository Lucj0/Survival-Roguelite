using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    //converts the hash "ismoving" into a number so its faster(?)
    private static readonly int IsMovingHash = Animator.StringToHash("isMoving");

    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 moveInput = InputManager.Actions.Player.Move.ReadValue<Vector2>();
        rb.linearVelocity = moveSpeed * moveInput;

        bool isMoving = moveInput != Vector2.zero;
        anim.SetBool(IsMovingHash, isMoving);
    }
}