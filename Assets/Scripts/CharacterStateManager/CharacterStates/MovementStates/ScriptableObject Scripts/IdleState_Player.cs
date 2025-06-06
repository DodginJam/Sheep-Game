using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Idle State Player", menuName = "States/MovementState/Player/IdleState"), Serializable]

public class IdleState_Player : IdleState
{
    public override void EnterState<T>(T stateManager)
    {
        base.EnterState(stateManager);

        if (stateManager is StateManager_Player stateManager_Player)
        {
            stateManager_Player.Controller.Move(Vector3.zero);
        }
    }

    public override void UpdateState<T>(T stateManager)
    {
        base.UpdateState(stateManager);

        if (stateManager is StateManager_Player stateManager_Player)
        {
            // Switch the state back to walking if the movement has increased above zero.
            if (stateManager_Player.InputHandler.InputMovement.sqrMagnitude >= 0.1f)
            {
                stateManager_Player.SwitchMovementState(stateManager_Player.MovementStateInstances.WalkingState);
            }
        }
    }

    public override void FixedUpdateState<T>(T stateManager)
    {
        base.FixedUpdateState(stateManager);

        if (stateManager is StateManager_Player stateManager_Player)
        {

        }
    }

    public override void LateUpdateState<T>(T stateManager)
    {
        base.LateUpdateState(stateManager);

        if (stateManager is StateManager_Player stateManager_Player)
        {

        }
    }

    public override void ExitState<T>(T stateManager)
    {
        base.ExitState(stateManager);

        if (stateManager is StateManager_Player stateManager_Player)
        {

        }
    }
}
