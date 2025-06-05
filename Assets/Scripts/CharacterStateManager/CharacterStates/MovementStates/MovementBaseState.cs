using UnityEngine;

public class MovementBaseState : BaseState
{
    [field: SerializeField]
    public float MovementSpeedModifier
    { get; private set; } = 1.0f;

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
