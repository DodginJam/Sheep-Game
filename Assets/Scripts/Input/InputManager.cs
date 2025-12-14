using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputSystem_Actions InputActions
    { get; private set; }

    private void Awake()
    {
        if (InputActions == null)
        {
            InputActions = new InputSystem_Actions();
            InputActions.Enable();
        }
    }
}
