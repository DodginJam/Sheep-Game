using UnityEngine;
using Unity.Netcode;

public class ControllerNetwork_AI : ControllerNetwork
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

        // Update the movement from the server to clients.
        if (IsServer)
        {
            UpdateFromServerToClientTickTimer += Time.deltaTime;

            if (UpdateFromServerToClientTickTimer >= UpdateFromServerToClientTickRate)
            {
                UpdateServerPositionToClientsRpc(transform.position);

                UpdateFromServerToClientTickTimer = 0;
            }
        }
    }

    protected override void Initialise()
    {
        if (NetworkManager.Singleton != null)
        {
            InputHandler.enabled = false;
            Controller.enabled = false;

            // For the AI, the input and controller should only be active on the server.
            if (IsServer)
            {
                InputHandler.enabled = true;
                Controller.enabled = true;
            }
        }
    }

    [Rpc(target: SendTo.NotServer)]
    public void UpdateServerPositionToClientsRpc(Vector3 positionToMoveTo)
    {
        transform.position = positionToMoveTo;
    }
}
