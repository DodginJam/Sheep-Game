using System;
using UnityEngine;

[Serializable]
public class CharacterValues : MonoBehaviour
{
    [field: SerializeField]
    public float BaseMovementSpeed
    { get; set; } = 5.0f;
}
