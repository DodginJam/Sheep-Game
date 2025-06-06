using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new NoAction State Player", menuName = "States/ActionState/Player/NoActionState"), Serializable]

public class NoAction_Player : NoAction
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
