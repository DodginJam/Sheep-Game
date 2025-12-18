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

            if (IsServer)
            {
                Controller.enabled = true;
            }

            if (IsOwner)
            {
                InputHandler.enabled = true;
            }
        }
    }

    [Rpc(target: SendTo.Server)]
    public void UpdateMovementInputRpc(Vector2 input)
    {
        InputHandler.MovementInput = input;
    }
}
