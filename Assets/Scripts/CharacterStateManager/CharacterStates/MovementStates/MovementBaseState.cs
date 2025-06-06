using UnityEngine;

public class MovementBaseState : BaseState
{
    [field: SerializeField]
    public float MovementSpeedModifier
    { get; private set; } = 1.0f;

    public override void EnterState<T>(T stateManager)
    {
        base.EnterState(stateManager);
    }

    public override void UpdateState<T>(T stateManager)
    {
        base.UpdateState(stateManager);
    }

    public override void FixedUpdateState<T>(T stateManager)
    {
        base.FixedUpdateState(stateManager);
    }

    public override void LateUpdateState<T>(T stateManager)
    {
        base.LateUpdateState(stateManager);
    }

    public override void ExitState<T>(T stateManager)
    {
        base.ExitState(stateManager);
    }
}
