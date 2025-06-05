using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public CharacterController Controller
    {  get; private set; }

    public Vector3 Velocity
    { get; private set; }

    [field: SerializeField]
    public float BaseMovementSpeed
    { get; private set; } = 5.0f;

    private void Awake()
    {
        if (Controller == null)
        {
            Controller = GetComponent<CharacterController>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        /*
        // Testing movement for quick implementation through old input system - temporary.
        float verticalMovement = Input.GetAxisRaw("Vertical");

        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        Velocity = BaseMovementSpeed * Time.deltaTime * new Vector3(horizontalMovement, 0, verticalMovement).normalized;

        Controller.Move(Velocity);
        */
    }
}
