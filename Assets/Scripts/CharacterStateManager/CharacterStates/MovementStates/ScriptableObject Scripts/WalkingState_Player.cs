using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Walking State Player", menuName = "States/MovementState/Player/WalkingState"), Serializable]
public class WalkingState_Player : WalkingState
{
    public override void EnterState<T>(T stateManager)
    {
        base.EnterState(stateManager);

        if (stateManager is StateManager_Player stateManager_Player)
        {

        }
    }

    public override void UpdateState<T>(T stateManager)
    {
        base.UpdateState(stateManager);

        if (stateManager is StateManager_Player stateManager_Player)
        {
            // Switch the state back to idel if the movement has reduced to around zero.
            if (stateManager_Player.InputHandler.InputMovement.sqrMagnitude < 0.1f)
            {
                stateManager_Player.SwitchMovementState(stateManager_Player.MovementStateInstances.IdleState);
            }
            else
            {
                Vector3 movementDirection = new Vector3(stateManager_Player.InputHandler.InputMovement.x, 0, stateManager_Player.InputHandler.InputMovement.y);

                stateManager_Player.Controller.Move(Time.deltaTime * MovementSpeedModifier * stateManager_Player.CharacterValues.BaseMovementSpeed * movementDirection);
            }

            // Handle Rotation.
            RotateToDirectionOfMovement(stateManager.gameObject, stateManager_Player.Controller.velocity.normalized, stateManager_Player);
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
