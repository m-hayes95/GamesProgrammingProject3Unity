using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        // Construct the player input actions input system.
        playerInputActions = new PlayerInputActions();
        // Enable the input actions Player actions map.
        playerInputActions.Player.Enable();
        // Subscribe to the player fire funciton perfomrd in the PlayerInputActions input system.
        playerInputActions.Player.Fire.performed += InputFireAction;
    }

    public Vector2 GetPlayerMovementVector2()
    {
        Vector2 inputVector2 = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Debug.Log(inputVector2);
        return inputVector2;
    }

    private void InputFireAction(InputAction.CallbackContext context)
    {
        Debug.Log(context);

        if (context.performed)
        {
            player.Fire();
        }
    }
}
