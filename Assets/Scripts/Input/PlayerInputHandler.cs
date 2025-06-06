using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    /// <summary>
    /// Reference to the C# wrapper class created as an instance at runtime to access the InputSystems actions maps.
    /// </summary>
    public InputSystem_Actions InputActions
    {  get; private set; }

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

    void Awake()
    {
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
        
    }

    public void OnEnable()
    {
        InputActions_PlayerActionMap.Enable();

        InputActions_PlayerActionMap.Move.performed += OnMovement;
        InputActions_PlayerActionMap.Move.canceled += OnMovement;
    }

    public void OnDisable()
    {
        InputActions_PlayerActionMap.Disable();

        InputActions_PlayerActionMap.Move.performed -= OnMovement;
        InputActions_PlayerActionMap.Move.canceled -= OnMovement;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 movementDirection = context.ReadValue<Vector2>();

        if (context.performed)
        {
            PlayerStateManager.SwitchState(PlayerStateManager.CurrentMovementState, PlayerStateManager.MovementStateInstances.WalkingState);
        }
        else if (context.canceled)
        {
            PlayerStateManager.SwitchState(PlayerStateManager.CurrentMovementState, PlayerStateManager.MovementStateInstances.IdleState);
        }

        Debug.Log($"Movement Input: {movementDirection}");
    }
}
