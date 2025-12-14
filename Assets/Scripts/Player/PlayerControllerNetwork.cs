using UnityEngine;
using Unity.Netcode;

public class PlayerControllerNetwork : NetworkBehaviour
{
    [field: SerializeField]
    public InputHandler InputHandler
    { get; set; }

    [field: SerializeField]
    public PlayerController PlayerController
    { get; set; }

    #region Ticks
    public const float UpdateFromServerToClientTickRate = 0.05f;

    public float UpdateFromServerToClientTimer
    { get; private set; } = 0;

    public const float UpdateFromClientToServerTickRate = 0.0166f;

    public float UpdateFromClientToServerTickTimer
    { get; private set; } = 0;
    #endregion

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (NetworkManager.Singleton != null)
        {
            InputHandler.enabled = false;
            PlayerController.enabled = false;

            if (IsServer)
            {
                PlayerController.enabled = true;
            }

            if (IsOwner)
            {
                InputHandler.enabled = true;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
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

    [Rpc(target: SendTo.Server)]
    public void UpdateMovementInputRpc(Vector2 input)
    {
        InputHandler.MovementInput = input;
    }
}
