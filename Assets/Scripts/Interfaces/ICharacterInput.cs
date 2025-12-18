using UnityEngine;

public interface ICharacterInput
{
    public Vector2 MovementInput
    { get; }

    public Vector2 LookInput
    { get; }

    public abstract void GetMovementInput();

    public abstract void GetLookInput();
}
