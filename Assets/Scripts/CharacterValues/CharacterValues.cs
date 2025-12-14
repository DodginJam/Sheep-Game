using UnityEngine;

public class CharacterValues : MonoBehaviour
{
    public float MovementSpeed
    { get; private set; }

    [field: SerializeField]
    public ControlValues StartingControllerValues
    { get; private set; }

    private void Awake()
    {
        if (StartingControllerValues != null)
        {
            MovementSpeed = StartingControllerValues.MovementSpeed;
        }
        else
        {
            Debug.LogError("No StartingControllerValues have been assigned.");
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
}
