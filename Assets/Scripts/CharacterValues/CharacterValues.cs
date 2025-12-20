using UnityEngine;

public class CharacterValues : MonoBehaviour, IMovementValues
{
    public float MovementSpeed
    { get; set; }

    [field: SerializeField]
    public CharacterInitialData DefaultControllerValues
    { get; private set; }

    private void Awake()
    {
        if (DefaultControllerValues != null)
        {
            IMovementValues.ApplyData(DefaultControllerValues.MovementData, this);
        }
        else
        {
            Debug.LogError("No DefaultControllerValues have been assigned.");
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
