using UnityEngine;
using Unity.Netcode;

public abstract class ControllerNetwork : NetworkBehaviour
{
    [field: SerializeField]
    public InputHandler InputHandler
    { get; set; }

    [field: SerializeField]
    public Controller Controller
    { get; set; }

    #region Ticks
    public const float UpdateFromServerToClientTickRate = 0.05f;

    public float UpdateFromServerToClientTickTimer
    { get; protected set; } = 0;

    public const float UpdateFromClientToServerTickRate = 0.0166f;

    public float UpdateFromClientToServerTickTimer
    { get; protected set; } = 0;
    #endregion

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        Initialise();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void LateUpdate()
    {

    }

    /// <summary>
    /// Initialise the required reference and values of the network controller.
    /// </summary>
    protected abstract void Initialise();
}
