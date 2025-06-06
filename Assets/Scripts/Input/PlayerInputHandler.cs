using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    /// <summary>
    /// Reference to the C# wrapper class created as an instance at runtime to access the InputSystems actions maps.
    /// </summary>
    public InputSystem_Actions InputActions
    { get; private set; }

    /// <summary>
    /// Reference to the Player actions as defined in the InputSystemActionAsset.
    /// </summary>
    public InputSystem_Actions.PlayerActions InputActions_PlayerActionMap
    { get; private set; }

    /// <summary>
    /// The state manager that the inputs should be sent to for access to it's various states and componments.
    /// </summary>
    [field: SerializeField]
    public StateManager_Player PlayerStateManager
    { get; private set; }

    /// <summary>
    /// The reference of the Horizontal and Vertical movement float values as read from the input system.
    /// </summary>
    [field: SerializeField]
    public Vector2 InputMovement
    { get; private set; }


    void Awake()
    {
        // Nullcheck for InputActions.
        InputActions = new InputSystem_Actions();
        if (InputActions != null)
        {
            InputActions_PlayerActionMap = InputActions.Player;
        }
        else
        {
            Debug.LogError("Unable to create a new instance of the InputSystem_Actions");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Read the movement input as a Vector2 to access 2D direction of movement.
        InputMovement = InputActions_PlayerActionMap.Move.ReadValue<Vector2>();
    }

    public void OnEnable()
    {
        InputActions_PlayerActionMap.Enable();
    }

    public void OnDisable()
    {
        InputActions_PlayerActionMap.Disable();
    }
}
