using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class InputHandler_AI : InputHandler
{
    protected override void Awake()
    {
        base.Awake();


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FindPlayerViaPath());
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

    }

    public override void GetMovementInput()
    {
        new NotImplementedException("Movement Not Yet Implemented");
    }

    public override void GetLookInput()
    {
        new NotImplementedException("Look Not Yet Implemented");
    }

    public IEnumerator FindPlayerViaPath()
    {
        bool playerLocationReached = false;
        Controller_Player player = GameObject.FindAnyObjectByType<Controller_Player>();
        NavMeshPath path = new NavMeshPath();
        int currentPathTargetIndex = 0;

        if (NavMesh.CalculatePath(transform.position, player.transform.position, NavMesh.AllAreas, path))
        {
            Debug.Log($"Path Calculated. Path Corners:{path.corners.Length}");
        }
        else
        {
            Debug.LogWarning("Path unable to be generated.");

            // Only set to true as to prevent running coroutine on failure.
            playerLocationReached = true;
        }

        // Draw the path on Debug.
        for (int i = 1; i < path.corners.Length; i++)
        {
            Debug.DrawLine(path.corners[i - 1], path.corners[i], Color.red, 20f);
        }

        while (playerLocationReached == false)
        {
            // If reached the end point, flip boolean flag to true to end loop.
            if (Vector3.Distance(transform.position, path.corners[path.corners.Length - 1]) < 0.5f)
            {
                playerLocationReached = true;
                Debug.Log("Path End reached.");
            }
            else
            {
                // FIX NEEDED - currently the direction is calculated in 3D space, yet the movement input is taken as 2D value - Y coordinate being dropped means loss of input values.

                // Find the direction to the next path corner in the index and assign that direction to movement input.
                Vector3 directionOfMovement = (path.corners[currentPathTargetIndex] - transform.position);

                MovementInput = new Vector2(directionOfMovement.x, directionOfMovement.z);

                Debug.Log(MovementInput);

                // Check if the distance to the next corner is less then minimum distance to allow change in the current path target via increasing the index.
                if (Vector3.Distance(transform.position, path.corners[currentPathTargetIndex]) < 0.1f)
                {
                    currentPathTargetIndex++;
                }
            }
            
            yield return null;
            MovementInput = Vector2.zero;
        }
    }
}
