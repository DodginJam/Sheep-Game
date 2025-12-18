using UnityEngine;

public abstract class InputHandler : MonoBehaviour, ICharacterInput
{
    public Vector2 MovementInput
    { get; set; }

    public Vector2 LookInput
    { get; set; }

    protected virtual void Awake()
    {
        Initialise();
    }

    protected virtual void OnEnable()
    {
        EnableListeners();
    }

    protected virtual void OnDisable()
    {
        DisableListeners();
    }

    protected abstract void Initialise();

    protected abstract void EnableListeners();

    protected abstract void DisableListeners();

    public abstract void GetMovementInput();

    public abstract void GetLookInput();
}
