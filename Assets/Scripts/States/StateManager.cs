using UnityEngine;

public class StateManager : MonoBehaviour
{
    /// <summary>
    /// The current state that the state machine is processing via update.
    /// </summary>
    public BaseState CurrentState
    {  get; private set; }

    #region States

    [field: SerializeField, Header("States")]
    public IdleState IdleState
    { get; private set; }

    [field: SerializeField]
    public MovementState WalkingState
    { get; private set; }

    #endregion

    [field: SerializeField, Header("Inital References")]
    public Controller Controller
    { get; private set; }

    public void Awake()
    {
        Initialise();
    }

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

    void Initialise()
    {
        if (IdleState == null)
        {
            Debug.LogError("The Idle state has not been assigned.");
            return;
        }

        SwitchState(IdleState);
    }
}
