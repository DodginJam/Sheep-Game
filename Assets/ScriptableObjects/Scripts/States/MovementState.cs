using UnityEngine;

public class MovementState : BaseState
{
    public MovementState(StateManager stateManager) : base(stateManager)
    {

    }

    public override void InitialiseState(StateManager stateManager)
    {

    }

    public override void OnEnter(StateManager stateManager)
    {
        // Debug.Log("Enter Movement State");
    }

    public override void OnUpdate(StateManager stateManager)
    {
        if (stateManager.Controller.InputInterface.MovementInput.sqrMagnitude < 0.001f)
        {
            stateManager.SwitchState(stateManager.IdleState);
            return;
        }

        CalculateMovementVelocity(stateManager);
    }

    public override void OnExit(StateManager stateManager)
    {
        // Debug.Log("Exit Movement State");

        stateManager.Controller.SetCharacterMovementVelocity(Vector3.zero);
    }

    protected virtual void CalculateMovementVelocity(StateManager stateManager)
    {
        // Reset the movement velocity so the new inputs override the last inputs.
        stateManager.Controller.SetCharacterMovementVelocity(Vector3.zero);

        if (stateManager.Controller.CharacterController != null && stateManager.Controller.InputInterface != null)
        {
            ICharacterInput characterInput = stateManager.Controller.InputInterface;
            CharacterValues characterValues = stateManager.Controller.CharacterValues;

            // Only output the X and Z axis of movement, taken from the Vector2 of the input movement.
            Vector3 globalMovement = new Vector3(characterInput.MovementInput.x, 0, characterInput.MovementInput.y).normalized;

            // Move the character along global movement lines.
            stateManager.Controller.SetCharacterMovementVelocity(characterValues.MovementSpeed * Time.deltaTime * globalMovement);
        }
        else
        {
            Debug.LogError("CharacterControllerComp is null or player input handler is null");
        }
    }
}
