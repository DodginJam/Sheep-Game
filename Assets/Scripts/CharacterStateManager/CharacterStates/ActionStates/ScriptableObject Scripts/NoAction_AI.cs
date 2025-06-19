using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new NoAction State AI", menuName = "States/ActionState/AI/NoActionState"), Serializable]

public class NoAction_AI : NoAction
{
    public override void EnterState<T>(T stateManager)
    {
        base.EnterState(stateManager);

        if (stateManager is StateManager_AI stateManager_AI)
        {

        }
    }

    public override void UpdateState<T>(T stateManager)
    {
        base.UpdateState(stateManager);

        if (stateManager is StateManager_AI stateManager_AI)
        {

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
