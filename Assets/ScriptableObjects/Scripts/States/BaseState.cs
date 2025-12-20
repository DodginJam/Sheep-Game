using UnityEngine;

[CreateAssetMenu(fileName = "BaseState", menuName = "Scriptable Objects/States/BaseState")]
public abstract class BaseState : ScriptableObject, IState
{
    public abstract void OnEnter(StateManager stateManager);
    public abstract void OnUpdate(StateManager stateManager);
    public abstract void OnExit(StateManager stateManager);
}
