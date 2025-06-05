using UnityEngine;

public class StateManager : MonoBehaviour
{
    /// <summary>
    /// The current movement related state of the character.
    /// </summary>
    public MovementBaseState CurrentMovementState
    {  get; private set; }

    /// <summary>
    /// The array of the movement states the state machine can access.
    /// </summary>
    [field: SerializeField]
    public MovementBaseState[] MovementStates
    { get; private set; }

    /// <summary>
    /// The current state representing an action the character is peforming, which may be independent of the movement state.
    /// </summary>
    public ActionBaseState CurrentActionState
    { get; private set; }

    /// <summary>
    /// The array of action state the state machine can access.
    /// </summary>
    [field: SerializeField]
    public ActionBaseState[] ActionStates
    { get; private set; }

    private void Awake()
    {
        // Ensure the current state are assigned a default starting value.
        CurrentMovementState = StartingStateEntry(CurrentMovementState, MovementStates);
        CurrentActionState = StartingStateEntry(CurrentActionState, ActionStates);
    }

    void Start()
    {

    }

    void Update()
    {
        if (CurrentMovementState != null)
        {
            CurrentMovementState.UpdateState(this);
        }
        else
        {
            Debug.LogError("The StateManager does not have an assigned Movement state.");
        }

        if (CurrentActionState != null)
        {
            CurrentActionState.UpdateState(this);
        }
        else
        {
            Debug.LogError("The StateManager does not have an assigned Action state.");
        }
    }

    private void FixedUpdate()
    {
        if (CurrentMovementState != null)
        {
            CurrentMovementState.UpdateState(this);
        }
        else
        {
            Debug.LogError("The StateManager does not have an assigned Movement state.");
        }

        if (CurrentActionState != null)
        {
            CurrentActionState.UpdateState(this);
        }
        else
        {
            Debug.LogError("The StateManager does not have an assigned Action state.");
        }
    }

    private void LateUpdate()
    {
        if (CurrentMovementState != null)
        {
            CurrentMovementState.UpdateState(this);
        }
        else
        {
            Debug.LogError("The StateManager does not have an assigned Movement state.");
        }

        if (CurrentActionState != null)
        {
            CurrentActionState.UpdateState(this);
        }
        else
        {
            Debug.LogError("The StateManager does not have an assigned Action state.");
        }
    }

    /// <summary>
    /// Used to change the current active state to a new provided state.
    /// </summary>
    /// <param name="stateToChange"></param>
    /// <param name="newState"></param>
    public void SwitchState(BaseState stateToChange, BaseState newState)
    {
        stateToChange.ExitState(this);

        stateToChange = newState;

        stateToChange.EnterState(this);
    }

    /// <summary>
    /// Ensure that the current state, if not assigned to a starting state already, can enter the first state in provided states array as the starting point.
    /// </summary>
    /// <param name="stateToAssign"></param>
    /// <param name="stateList"></param>
    public T StartingStateEntry<T>(T stateToAssign, T[] stateList) where T : BaseState
    {
        if (stateToAssign == null)
        {
            if (stateList != null && stateList.Length > 0 && stateList[0] != null)
            {
                return stateList[0];
            }
            else
            {
                Debug.LogError("No valid starting state able to be found through the provided state list.");
                return default(T);
            }
        }
        else
        {
            Debug.Log("State has already been assigned, no need to assign reference.");
            return default(T);
        }
    }
}
