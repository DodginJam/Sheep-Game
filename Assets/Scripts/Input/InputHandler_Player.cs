using UnityEngine;

/// <summary>
/// Derived input handler focused on providing support for player (real) inputs.
/// </summary>
public class InputHandler_Player : InputHandler
{
    public InputManager InputManager
    {  get; private set; }

    public InputSystem_Actions.PlayerActions PlayerActionMap
    { get; private set; }

    protected override void Awake()
    {
        base.Awake();


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AssignMovementInput(PlayerActionMap.Move.ReadValue<Vector2>());

        AssignLookInput(PlayerActionMap.Look.ReadValue<Vector2>());
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void EnableListeners()
    {
        
    }

    protected override void DisableListeners()
    {

    }

    protected override void Initialise()
    {
        InputManager = GameObject.FindFirstObjectByType<InputManager>();

        if (InputManager != null)
        {
            PlayerActionMap = InputManager.InputActions.Player;
        }
        else
        {
            Debug.LogError("The Input Manager has not been able to be found");
        }
    }

    public override void AssignMovementInput(Vector2 movementInput)
    {
        MovementInput = movementInput;
    }

    public override void AssignLookInput(Vector2 lookInput)
    {
        LookInput = lookInput;
    }
}
