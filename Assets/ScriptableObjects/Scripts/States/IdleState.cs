using System;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(StateManager stateManager) : base(stateManager)
    {

    }

    public override void InitialiseState(StateManager stateManager)
    {

    }

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
