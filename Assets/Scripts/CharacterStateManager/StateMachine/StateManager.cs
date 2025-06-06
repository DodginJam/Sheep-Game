using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    /// <summary>
    /// The current movement related state of the character.
    /// </summary>
    public MovementBaseState CurrentMovementState
    {  get; private set; }

    [Serializable]
    public class MovementStates
    {
        [field: SerializeField]
        public IdleState IdleState
        { get; private set; }

        [field: SerializeField]
        public WalkingState WalkingState
        { get; private set; }
    }

    [field: SerializeField, Header("Movement States")]
    public MovementStates MovementStateInstances
    { get; private set; }

    /// <summary>
    /// The current state representing an action the character is peforming, which may be independent of the movement state.
    /// </summary>
    public ActionBaseState CurrentActionState
    { get; private set; }

    [Serializable]
    public class ActionStates
    {
        [field: SerializeField]
        public NoAction NoActionState
        { get; private set; }
    }

    [field: SerializeField, Header("Action States")]
    public ActionStates ActionStateInstances
    { get; private set; }

    /// <summary>
    /// The values of the character associated with movement etc.
    /// </summary>
    [field: SerializeField]
    public CharacterValues CharacterValues
    { get; private set; }

    protected virtual void Awake()
    {
        // Ensure the current state are assigned a default starting value.
        CurrentMovementState = StartingStateEntry(CurrentMovementState, MovementStateInstances.IdleState);
        CurrentActionState = StartingStateEntry(CurrentActionState, ActionStateInstances.NoActionState);

        if (CharacterValues == null)
        {
            if (TryGetComponent<CharacterValues>(out CharacterValues characterValues))
            {
                CharacterValues = characterValues;
            }
            else
            {
                Debug.LogError("Unable to locate the character values on the same gameobject as the state manager.");
            }
        }
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
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

        Debug.Log($"Current Movement State {CurrentMovementState}");
    }

    protected virtual void FixedUpdate()
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

    protected virtual void LateUpdate()
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
    /// Used to change the current Movement state to a new provided state.
    /// </summary>
    /// <param name="stateToChange"></param>
    /// <param name="newState"></param>
    public void SwitchMovementState(MovementBaseState newState)
    {
        if (CurrentMovementState != null)
        {
            CurrentMovementState.ExitState(this);
        }

        CurrentMovementState = newState;

        CurrentMovementState.EnterState(this);
    }

    /// <summary>
    /// Used to change the current Action state to a new provided state.
    /// </summary>
    /// <param name="stateToChange"></param>
    /// <param name="newState"></param>
    public void SwitchActionState(ActionBaseState newState)
    {
        if (CurrentActionState != null)
        {
            CurrentActionState.ExitState(this);
        }

        CurrentActionState = newState;

        CurrentActionState.EnterState(this);
    }

    /// <summary>
    /// Ensure that the current state, if not assigned to a starting state already, can enter the first state in provided states array as the starting point.
    /// </summary>
    /// <param name="stateToAssign"></param>
    /// <param name="stateList"></param>
    public T StartingStateEntry<T>(T stateToAssign, T entryState) where T : BaseState
    {
        if (stateToAssign == null)
        {
            if (entryState != null)
            {
                return entryState;
            }
            else
            {
                Debug.LogError("Entry state is not a valid reference - is null.");
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
