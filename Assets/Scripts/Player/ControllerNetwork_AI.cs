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
            UpdatePositionToClientsRpc(transform.position);
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

    [Rpc(target: SendTo.NotServer)]
    public void UpdatePositionToClientsRpc(Vector3 positionToMoveTo)
    {
        transform.position = positionToMoveTo;
    }
}
