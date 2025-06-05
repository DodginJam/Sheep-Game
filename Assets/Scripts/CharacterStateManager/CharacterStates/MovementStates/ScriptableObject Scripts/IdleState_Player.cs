using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Idle State Player", menuName = "States/MovementState/Player/IdleState"), Serializable]

public class IdleState_Player : IdleState
{
    public override void EnterState(StateManager stateManager)
    {
        base.EnterState(stateManager);
    }

    public override void UpdateState(StateManager stateManager)
    {
        base.UpdateState(stateManager);
    }

    public override void FixedUpdateState(StateManager stateManager)
    {
        base.FixedUpdateState(stateManager);
    }

    public override void LateUpdateState(StateManager stateManager)
    {
        base.LateUpdateState(stateManager);
    }

    public override void ExitState(StateManager stateManager)
    {
        base.ExitState(stateManager);
    }
}
