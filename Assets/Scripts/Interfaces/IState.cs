using UnityEngine;

public interface IState
{
    public void OnEnter(StateManager stateManager);

    public void OnUpdate(StateManager stateManager);

    public void OnExit(StateManager stateManager);
}
