using UnityEngine;

[CreateAssetMenu(fileName = "MovementData", menuName = "Scriptable Objects/MovementData")]
public class MovementData : ScriptableObject, IMovementValues
{
    [field: SerializeField]
    public float MovementSpeed
    { get; set; }
}
