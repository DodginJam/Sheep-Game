using UnityEngine;

[CreateAssetMenu(fileName = "ControlValues", menuName = "Scriptable Objects/ControlValues")]
public class ControlValues : ScriptableObject
{
    [field: SerializeField]
    public float MovementSpeed
    { get; private set; }
}
