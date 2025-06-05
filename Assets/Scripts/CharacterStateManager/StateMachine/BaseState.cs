using UnityEngine;

public abstract class BaseState : ScriptableObject
{
    public virtual void EnterState(StateManager stateManager)
    {

    }

    public virtual void UpdateState(StateManager stateManager)
    {

    }

    public virtual void FixedUpdateState(StateManager stateManager)
    {

    }

    public virtual void LateUpdateState(StateManager stateManager)
    {

    }

    public virtual void ExitState(StateManager stateManager)
    {
        
    }
}
