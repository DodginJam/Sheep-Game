using UnityEngine;

public class StateManager : MonoBehaviour
{
    public BaseState CurrentState
    {  get; private set; }

    public void Update()
    {
        CurrentState.OnUpdate(this);
    }

    public void SwitchState(BaseState newState)
    {
        if (CurrentState != null)
        {
            CurrentState.OnExit(this);
        }

        CurrentState = newState;

        CurrentState.OnEnter(this);
    }
}
