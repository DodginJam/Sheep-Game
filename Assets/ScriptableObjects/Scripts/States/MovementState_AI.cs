using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class MovementState_AI : MovementState
{
    public MovementState_AI(StateManager stateManager) : base(stateManager)
    {

    }

    public override void InitialiseState(StateManager stateManager)
    {

    }

    public override void OnEnter(StateManager stateManager)
    {
        Debug.Log("Enter Movement_AI State");

        stateManager.CurrentPathCornerIndex = 0;

        if (stateManager.Controller is not IAILocomotion ai)
        {
            return;
        }
        ai.Path = null;

        if (stateManager.TryGetComponent<InputHandler_AI>(out InputHandler_AI inputHandler_AI))
        {
            ai.AIInput = inputHandler_AI;
        }
        else
        {
            Debug.LogError("Unable to locate the InputHandler_AI component.");
        }
    }

    public override void OnUpdate(StateManager stateManager)
    {
        if (stateManager.Controller is not IAILocomotion ai)
        {
            return;
        }

        // Generate the path again if - the path is null, or, the target position is outside the accepted distance from the current end of path.
        if (ai.Path == null || (ai.Path != null && Vector3.Distance(stateManager.TargetTransform.position, ai.Path.corners[ai.Path.corners.Length - 1]) > 0.2f))
        {
            ai.Path = CalculatePath(stateManager.TargetTransform.position, stateManager.transform.position);

            // Draw the path on Debug.
            for (int i = 1; i < ai.Path.corners.Length; i++)
            {
                Debug.DrawLine(ai.Path.corners[i - 1], ai.Path.corners[i], Color.red);
            }

            // Reset the current index tracking the next corner to be directed towards on new path generation.
            stateManager.CurrentPathCornerIndex = 0;
        }

        // If reached the end point.
        if (Vector3.Distance(stateManager.transform.position, ai.Path.corners[ai.Path.corners.Length - 1]) < 1f)
        {
            Debug.Log("Path End reached.");
            stateManager.SwitchState(stateManager.IdleState);
            return;
        }
        else
        {
            // FIX NEEDED - currently the direction is calculated in 3D space, yet the movement input is taken as 2D value - Y coordinate being dropped means loss of input values.

            // Check if the distance to the next corner is less then minimum distance to allow change in the current path target via increasing the index.
            if (Vector3.Distance(stateManager.transform.position, ai.Path.corners[stateManager.CurrentPathCornerIndex]) < 0.3f)
            {
                stateManager.CurrentPathCornerIndex++;
            }

            // Find the direction to the current target path corner in the index and assign that direction to movement input.
            Vector3 directionOfMovement = (ai.Path.corners[stateManager.CurrentPathCornerIndex] - stateManager.transform.position);
            ai.AIInput.AssignMovementInput(new Vector2(directionOfMovement.x, directionOfMovement.z));
        }

        CalculateMovementVelocity(stateManager);
    }

    public override void OnExit(StateManager stateManager)
    {
        Debug.Log("Exit Movement_AI State");

        stateManager.Controller.SetCharacterMovementVelocity(Vector3.zero);

        stateManager.TargetTransform = null;
    }

    public NavMeshPath CalculatePath(Vector3 positionToPathTowards, Vector3 currentPosition)
    {
        NavMeshPath path = new NavMeshPath();

        if (!NavMesh.CalculatePath(currentPosition, positionToPathTowards, NavMesh.AllAreas, path))
        {
            Debug.LogWarning("Path unable to be generated.");
        }

        return path;
    }
}
