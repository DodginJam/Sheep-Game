using UnityEngine;
using Unity.Netcode;

public class ControllerNetwork_Player : ControllerNetwork
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void LateUpdate()
    {
        base.LateUpdate();

        // Send the client input to the server.
        if (IsOwner && IsClient)
        {
            UpdateFromClientToServerTickTimer += Time.deltaTime;

            if (UpdateFromClientToServerTickTimer >= UpdateFromClientToServerTickRate)
            {
                UpdateMovementInputRpc(InputHandler.MovementInput);

                UpdateFromClientToServerTickTimer = 0;
            }
        }
    }

    protected override void Initialise()
    {
        if (NetworkManager.Singleton != null)
        {
            InputHandler.enabled = false;
            Controller.enabled = false;
            StateManager.enabled = false;

            // For the players, only the controller should be active on the sever, while the input is active on the clients only.
            if (IsServer)
            {
                Controller.enabled = true;
                StateManager.enabled = true;
            }

            if (IsOwner)
            {
                InputHandler.enabled = true;

                // Assign the current owner to the camera manager.
                GameObject.FindAnyObjectByType<CameraManager>().AssignOwner(Controller);
            }
        }
    }

    [Rpc(target: SendTo.Server)]
    public void UpdateMovementInputRpc(Vector2 input)
    {
        InputHandler.MovementInput = input;
    }
}
