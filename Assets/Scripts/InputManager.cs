using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputActions Actions;

    void Awake()
    {
        Actions = new InputActions();
    }

    void OnEnable()
    {
        Actions.Player.Enable();
    }

    void OnDisable()
    {
        Actions.Player.Disable();
    }
}