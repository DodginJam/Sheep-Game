using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StateManager_AI : StateManager
{
    [field: SerializeField, Header("AI Controller References")]
    public NavMeshAgent Agent
    {  get; private set; }

    protected override void Awake()
    {
        base.Awake();

        // Locate Character Controller if it is missing.
        if (Agent == null)
        {
            if (TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
            {
                Agent = agent;
            }
            else
            {
                Debug.LogError("Unable to locate a NavMeshAgent on the same gameobject as the state manager.");
            }
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }
}
