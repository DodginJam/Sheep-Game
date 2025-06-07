using UnityEngine;

public class MovementBaseState : BaseState
{
    public float BaseGravity
    { get; set; } = -9.81f;

    [field: SerializeField]
    public float MovementSpeedModifier
    { get; private set; } = 1.0f;

    [field: SerializeField]
    public float RotationSpeedModifier
    { get; private set; } = 1.0f;

    /// <summary>
    /// Should rotation occur towards the direction of movement.
    /// </summary>
    [field: SerializeField]
    public RotationStatus RotateToMovementDirectionAllowed
    { get; private set; }

    public override void EnterState<T>(T stateManager)
    {
        base.EnterState(stateManager);
    }

    public override void UpdateState<T>(T stateManager)
    {
        base.UpdateState(stateManager);
    }

    public override void FixedUpdateState<T>(T stateManager)
    {
        base.FixedUpdateState(stateManager);
    }

    public override void LateUpdateState<T>(T stateManager)
    {
        base.LateUpdateState(stateManager);
    }

    public override void ExitState<T>(T stateManager)
    {
        base.ExitState(stateManager);
    }

    /// <summary>
    /// Rotations options during movement states.
    /// </summary>
    public enum RotationStatus
    {
        Disallowed,
        Allowed
    }

    /// <summary>
    /// Called every update frame when valid, rotates the given game object towards the direction of movement by the current roation speed allowed.
    /// </summary>
    /// <param name="objectToRotate"></param>
    /// <param name="directionOfMovement"></param>
    /// <param name="stateManager"></param>
    public void RotateToDirectionOfMovement(GameObject objectToRotate, Vector3 directionOfMovement, StateManager stateManager)
    {
        if (directionOfMovement == Vector3.zero)
        {
            return;
        }

        Vector3 newRotation = Vector3.RotateTowards(objectToRotate.transform.forward, directionOfMovement.normalized, RotationSpeedModifier * Time.deltaTime * stateManager.CharacterValues.BaseRotationSpeed, 0.0f);
        objectToRotate.transform.rotation = Quaternion.LookRotation(newRotation);
    }
}
