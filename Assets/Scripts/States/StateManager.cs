using UnityEngine;

public class StateManager : MonoBehaviour
{
    /// <summary>
    /// The current state that the state machine is processing via update.
    /// </summary>
    public BaseState CurrentState
    {  get; private set; }

    #region States

    public IdleState IdleState
    { get; private set; }

    public MovementState MovementState
    { get; private set; }

    #endregion

    [field: SerializeField, Header("Inital References")]
    public Controller Controller
    { get; private set; }

    public Transform TargetTransform
    { get; set; }

    public int CurrentPathCornerIndex
    { get; set; }

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
        if (Controller is Controller_Player controllerPlayer)
        {
            IdleState = new IdleState(this);
            MovementState = new MovementState(this);
        }
        else if (Controller is Controller_AI controllerAI)
        {
            IdleState = new IdleState_AI(this);
            MovementState = new MovementState_AI(this);
        }

        if (IdleState == null)
        {
            Debug.LogError("The Idle state has not been assigned.");
            return;
        }

        SwitchState(IdleState);
    }
}
