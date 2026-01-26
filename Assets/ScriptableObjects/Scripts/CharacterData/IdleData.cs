using UnityEngine;

[CreateAssetMenu(fileName = "IdleData", menuName = "Scriptable Objects/IdleData")]
public class IdleData : ScriptableObject
{
    [field: SerializeField]
    public float AggroDistance
    { get; private set; } = 10.0f;

    [field: SerializeField]
    public LayerMask TargetLayer
    { get; private set; }
}
