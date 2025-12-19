using UnityEngine;

public abstract class Controller : MonoBehaviour, ICharacterController
{
    public ICharacterInput InputInterface
    { get; set; }

    [field: SerializeField]
    public CharacterController CharacterController
    { get; private set; }

    [field: SerializeField]
    public CharacterValues CharacterValues
    { get; private set; }

    /// <summary>
    /// Contains the velocity calculated from the movement inputs, which is applied to the character controllers overall movement per frame.
    /// </summary>
    public Vector3 CharacterMovementVelocity
    { get; private set; }

    /// <summary>
    /// Contains the velocity calculated from the forces applied to the character, which is applied to the character controllers overall movement per frame.
    /// </summary>
    public Vector3 CharacterForcesVelocity
    { get; private set; }

    private bool isGrounded;
    public bool IsGrounded
    {
        get
        {
            return isGrounded;
        }

        set
        {
            isGrounded = value;
            GroundedStateChange = true;
        }
    }

    /// <summary>
    /// Flag that is set for when the IsGrounded setter is changed.
    /// </summary>
    private bool GroundedStateChange
    { get; set; }

    /// <summary>
    /// The layers then count as walkable on for the IsGrounded status of the character.
    /// </summary>
    [field: SerializeField, Tooltip("The layers then count as walkable on for the IsGrounded status of the character.")]
    public LayerMask WalkableLayers
    { get; private set; }

    protected virtual void Awake()
    {
        Initialise();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleMovement(CharacterValues);

        UpdateGroundedStatus();

        SimulateGravity();

        CharacterController.Move(CharacterMovementVelocity + (CharacterForcesVelocity * Time.deltaTime));
    }

    public virtual void Initialise()
    {
        if (this.TryGetComponent<ICharacterInput>(out ICharacterInput characterInput))
        {
            InputInterface = characterInput;
            Debug.Log("Input system found.");
        }
        else
        {
            Debug.LogError("Unable to locate character input system.");
        }
    }

    /// <summary>
    /// Applies the movement inputs to the desired movement directions of the character controller and store this movement in the Values Movement Velocity.
    /// </summary>
    public void HandleMovement(CharacterValues characterValues)
    {
        // Reset the movement velocity so the new inputs override the last inputs.
        CharacterMovementVelocity = Vector3.zero;

        if (CharacterController != null && InputInterface != null)
        {
            if (InputInterface.MovementInput.x == 0 && InputInterface.MovementInput.y == 0)
            {
                return;
            }

            // Only output the X and Z axis of movement, taken from the Vector2 of the input movement.
            Vector3 globalMovement = new Vector3(InputInterface.MovementInput.x, 0, InputInterface.MovementInput.y).normalized;

            // Move the character along global movement lines.
            CharacterMovementVelocity = characterValues.MovementSpeed * Time.deltaTime * globalMovement;
        }
        else
        {
            Debug.LogError("CharacterControllerComp is null or player input handler is null");
        }
    }

    /// <summary>
    /// Simulates the downward force to applt the character controller.
    /// </summary>
    public void SimulateGravity()
    {
        // The bool is to flag if the player should have their gravity reset.
        bool resetGravityToZero = false;

        // If the grounded state has changed, flag to reset gravity to zero, as it means the player has just change their grounded state.
        if (GroundedStateChange)
        {
            resetGravityToZero = true;

            // Reset the grounded state change flag to prevent further checks.
            GroundedStateChange = false;
        }

        // If not grounded, apply gravity.
        if (IsGrounded)
        {
            // Setting the gravity value when grounded as it should remain a constant to allow natural falls and to stop playing from bumping down shallow slopes
            CharacterForcesVelocity = new Vector3(CharacterForcesVelocity.x, -2, CharacterForcesVelocity.z);
        }
        else
        {
            // If the flag to reset gravity has occured, hard set the gravity to zero so that the player falls like a rigidbody without the already constant "IsGrounded" downward force already starting with.
            if (resetGravityToZero)
            {
                CharacterForcesVelocity = new Vector3(CharacterForcesVelocity.x, 0, CharacterForcesVelocity.z);
            }
            else
            {
                CharacterForcesVelocity += new Vector3(0, Physics.gravity.y * Time.deltaTime, 0);
            }
        }
    }

    /// <summary>
    /// Using SphereCasts, check if the character controller is in contact with the ground.
    /// </summary>
    public void UpdateGroundedStatus()
    {
        float sphereCastRadius = CharacterController.radius;
        Vector3 sphereCastDirection = Vector3.down;

        // The origin is at the base of the character controller minus the radius of the sphere cast, ensuring the spherecast and feet of controller capusle line up correctly.
        Vector3 sphereCastOrigin = transform.position + new Vector3(0, (CharacterController.height / 2) - (sphereCastRadius), 0);

        float sphereCastMaxDistance = 0.1f;

        bool isGrounded = Physics.SphereCast(sphereCastOrigin, sphereCastRadius, sphereCastDirection, out _, sphereCastMaxDistance, WalkableLayers);

        if (isGrounded != IsGrounded)
        {
            IsGrounded = isGrounded;
        }

        // Debugging
           
        // Debug.DrawLine(transform.position, sphereCastOrigin, Color.red); // The origin point of the sphere cast from the transform centre.
        // Debug.DrawLine(sphereCastOrigin, sphereCastOrigin + Vector3.down * sphereCastMaxDistance, Color.blue); // The sphere origin to sphere max DistanceMax.
        // Debug.Log($"Is Grounded: {isGrounded}");
        
    }
}
