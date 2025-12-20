using System;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "Scriptable Objects/States/IdleState")]
public class IdleState : BaseState
{
    public override void OnEnter(StateManager stateManager)
    {
        Debug.Log("Enter Idle State");
    }

    public override void OnUpdate(StateManager stateManager)
    {
        if (stateManager.Controller.InputInterface.MovementInput.sqrMagnitude > 0.01f || stateManager.Controller.InputInterface.MovementInput.sqrMagnitude < -0.01f)
        {
            stateManager.SwitchState(stateManager.WalkingState);
        }
    }

    public override void OnExit(StateManager stateManager)
    {
        Debug.Log("Exit Idle State");
    }
}
