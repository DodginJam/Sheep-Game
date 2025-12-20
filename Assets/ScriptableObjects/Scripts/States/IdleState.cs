using System;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "Scriptable Objects/States/IdleState")]
public class IdleState : BaseState
{
    public override void OnEnter(StateManager stateManager)
    {
        Debug.Log("Enter Idle State");

        stateManager.Controller.SetCharacterMovementVelocity(Vector3.zero);
    }

    public override void OnUpdate(StateManager stateManager)
    {
        if (stateManager.Controller.InputInterface.MovementInput.sqrMagnitude > 0.01f || stateManager.Controller.InputInterface.MovementInput.sqrMagnitude < -0.01f)
        {
            stateManager.SwitchState(stateManager.MovementState);
            return;
        }


    }

    public override void OnExit(StateManager stateManager)
    {
        Debug.Log("Exit Idle State");
    }
}
