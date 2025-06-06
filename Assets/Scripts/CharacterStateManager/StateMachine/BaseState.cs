using UnityEngine;

public abstract class BaseState : ScriptableObject
{
    public virtual void EnterState<T>(T stateManager) where T : StateManager
    {

    }

    public virtual void UpdateState<T>(T stateManager) where T : StateManager
    {

    }

    public virtual void FixedUpdateState<T>(T stateManager) where T : StateManager
    {

    }

    public virtual void LateUpdateState<T>(T stateManager) where T : StateManager
    {

    }

    public virtual void ExitState<T>(T stateManager) where T : StateManager
    {
        
    }
}
