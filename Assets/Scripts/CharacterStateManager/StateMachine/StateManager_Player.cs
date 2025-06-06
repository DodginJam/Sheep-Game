using UnityEngine;

public class StateManager_Player : StateManager
{
    [field: SerializeField, Header("Player Controller References")]
    public CharacterController Controller
    {  get; private set; }

    [field: SerializeField]
    public PlayerInputHandler InputHandler
    { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        // Locate Character Controller if it is missing.
        if (Controller == null)
        {
            if (TryGetComponent<CharacterController>(out CharacterController controller))
            {
                Controller = controller;
            }
            else
            {
                Debug.LogError("Unable to locate a character controller on the same gameobject as the state manager.");
            }
        }

        // Locate the InputHandler script if it is missing.
        if (InputHandler == null)
        {
            if (TryGetComponent<PlayerInputHandler>(out PlayerInputHandler playerInputHandler))
            {
                InputHandler = playerInputHandler;
            }
            else
            {
                Debug.LogError("Unable to locate a PlayerInputHandler on the same gameobject as the state manager.");
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
