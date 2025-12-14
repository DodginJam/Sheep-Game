using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public InputManager InputManager
    {  get; private set; }

    public InputSystem_Actions.PlayerActions PlayerActionMap
    { get; private set; }

    public Vector2 MovementInput
    { get; set; }

    public Vector2 LookInput
    { get; private set; }

    private void Awake()
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput = ReadMovementInput();
        LookInput = ReadLookInput();
    }

    private void OnEnable()
    {
        EnableListeners();
    }

    private void OnDisable()
    {
        DisableListeners();
    }

    public void EnableListeners()
    {

    }

    public void DisableListeners()
    {

    }

    public Vector2 ReadMovementInput()
    {
        return PlayerActionMap.Move.ReadValue<Vector2>();
    }

    public Vector2 ReadLookInput()
    {
        return PlayerActionMap.Look.ReadValue<Vector2>();
    }
}
