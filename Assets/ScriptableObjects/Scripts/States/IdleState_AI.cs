using System;
using UnityEngine;

public class IdleState_AI : IdleState
{
    public IdleState_AI(StateManager stateManager) : base(stateManager)
    {

    }

    public float AggroDistance
    { get; private set; } = 10.0f;

    public LayerMask TargetLayer
    { get; private set; }

    public override void InitialiseState(StateManager stateManager)
    {
        AggroDistance = stateManager.Controller.CharacterValues.DefaultControllerValues.IdleData.AggroDistance;

        TargetLayer = stateManager.Controller.CharacterValues.DefaultControllerValues.IdleData.TargetLayer;
    }

    public override void OnEnter(StateManager stateManager)
    {
        // Debug.Log("Enter IdleState_AI State");

        stateManager.Controller.SetCharacterMovementVelocity(Vector3.zero);
    }

    public override void OnUpdate(StateManager stateManager)
    {
        // Debug.Log($"Distance to Player: {Vector3.Distance(stateManager.transform.position, GameObject.FindAnyObjectByType<Controller_Player>().transform.position)}");

        Collider[] collideredItems = Physics.OverlapSphere(stateManager.transform.position, AggroDistance, TargetLayer);

        if (collideredItems.Length != 0)
        {
            for (int i = 0; i < collideredItems.Length; i ++)
            {
                if (collideredItems[i].TryGetComponent<Controller_Player>(out Controller_Player controller_Player))
                {
                    stateManager.TargetTransform = controller_Player.transform;
                }
            }
        }

        if (stateManager.TargetTransform != null)
        {
            stateManager.SwitchState(stateManager.MovementState);
        }
    }

    public override void OnExit(StateManager stateManager)
    {
        // Debug.Log("Exit IdleState_AI State");
    }
}
