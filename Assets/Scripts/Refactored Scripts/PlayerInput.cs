using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Player player; // Ref for player fire method.
    // Ref to player input actions.
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
        // Recieve the vector 2 reading from input action map and return the value.
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

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }
}
