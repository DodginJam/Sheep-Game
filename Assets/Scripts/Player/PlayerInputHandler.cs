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
    }

    public void OnDisable()
    {
        InputActions_PlayerActionMap.Disable();
    }
}
