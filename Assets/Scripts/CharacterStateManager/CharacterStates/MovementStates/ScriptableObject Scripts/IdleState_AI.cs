using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Idle State AI", menuName = "States/MovementState/AI/IdleState"), Serializable]

public class IdleState_AI : IdleState
{
    public override void EnterState<T>(T stateManager)
    {
        base.EnterState(stateManager);

        if (stateManager is StateManager_AI stateManager_AI)
        {
            // stateManager_Player.Controller.Move(Vector3.zero);
        }
    }

    public override void UpdateState<T>(T stateManager)
    {
        base.UpdateState(stateManager);

        if (stateManager is StateManager_AI stateManager_AI)
        {
            /*
            // Switch the state back to walking if the movement has increased above zero.
            if (stateManager_Player.InputHandler.InputMovement.sqrMagnitude >= 0.1f)
            {
                stateManager_Player.SwitchMovementState(stateManager_Player.MovementStateInstances.WalkingState);
            }
            */
        }
    }

    public override void FixedUpdateState<T>(T stateManager)
    {
        base.FixedUpdateState(stateManager);

        if (stateManager is StateManager_AI stateManager_AI)
        {

        }
    }

    public override void LateUpdateState<T>(T stateManager)
    {
        base.LateUpdateState(stateManager);

        if (stateManager is StateManager_AI stateManager_AI)
        {

        }
    }

    public override void ExitState<T>(T stateManager)
    {
        base.ExitState(stateManager);

        if (stateManager is StateManager_AI stateManager_AI)
        {

        }
    }
}
