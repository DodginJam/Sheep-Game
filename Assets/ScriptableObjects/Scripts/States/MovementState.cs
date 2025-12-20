using UnityEngine;

[CreateAssetMenu(fileName = "MovementState", menuName = "Scriptable Objects/States/MovementState")]
public class MovementState : BaseState
{
    public override void OnEnter(StateManager stateManager)
    {
        Debug.Log("Enter Movement State");
    }

    public override void OnUpdate(StateManager stateManager)
    {
        if (stateManager.Controller.InputInterface.MovementInput.sqrMagnitude < 0.01f && stateManager.Controller.InputInterface.MovementInput.sqrMagnitude > -0.01f)
        {
            stateManager.SwitchState(stateManager.IdleState);
        }
    }

    public override void OnExit(StateManager stateManager)
    {
        Debug.Log("Exit Movement State");
    }
}
