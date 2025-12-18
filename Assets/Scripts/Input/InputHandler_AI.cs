using System;
using UnityEngine;
using UnityEngine.AI;

public class InputHandler_AI : InputHandler
{
    public NavMeshAgent NavigationAgent
    { get; private set; }

    protected override void Awake()
    {
        base.Awake();


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();

        GetLookInput();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void EnableListeners()
    {
        
    }

    protected override void DisableListeners()
    {

    }

    protected override void Initialise()
    {
        if (this.TryGetComponent<NavMeshAgent>(out NavMeshAgent navigationAgent))
        {
            NavigationAgent = navigationAgent;
        }
        else
        {
            Debug.LogError("Unable to locate the navigation agent component");
        }
    }

    public override void GetMovementInput()
    {
        new NotImplementedException("Movement Not Yet Implemented");
    }

    public override void GetLookInput()
    {
        new NotImplementedException("Look Not Yet Implemented");
    }
}
