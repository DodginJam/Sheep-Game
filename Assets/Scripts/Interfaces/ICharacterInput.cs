using UnityEngine;

/// <summary>
/// Character Inputs Interface.
/// </summary>
[Tooltip("Character Inputs Interface")]
public interface ICharacterInput
{
    /// <summary>
    /// Holds the value of the movement input directions as a Vector2 (x, y).
    /// </summary>
    public Vector2 MovementInput
    { get; }

    /// <summary>
    /// Holds the value of the look input directions as a Vector2 (x, y).
    /// </summary>
    public Vector2 LookInput
    { get; }

    /// <summary>
    /// Method inteneded to retrive the values used for movement and store them into the movement input variable.
    /// </summary>
    public abstract void AssignMovementInput(Vector2 movementInput);

    /// <summary>
    /// Method inteneded to retrive the values used for look and store them into the movement input variable.
    /// </summary>
    public abstract void AssignLookInput(Vector2 movementInput);
}
