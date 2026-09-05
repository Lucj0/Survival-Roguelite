using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    [SerializeField] private float threshold = 0.05f;
    public int Facing { get; private set; } = 1;

    void Update()
    {
        Vector2 moveInput = InputManager.Actions.Player.Move.ReadValue<Vector2>();
        float size = Mathf.Abs(transform.localScale.x);

        if (Mathf.Abs(moveInput.x) > threshold)
        {
            Facing = moveInput.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(size * Facing, transform.localScale.y, transform.localScale.z);
        }
    }
}