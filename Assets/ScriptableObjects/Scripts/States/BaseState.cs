using UnityEngine;

public abstract class BaseState : IState
{
    public BaseState(StateManager stateManager)
    {
        InitialiseState(stateManager);
    }

    public abstract void InitialiseState(StateManager stateManager);
    public abstract void OnEnter(StateManager stateManager);
    public abstract void OnUpdate(StateManager stateManager);
    public abstract void OnExit(StateManager stateManager);
}
