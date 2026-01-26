using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInitialData", menuName = "Scriptable Objects/CharacterInitialData")]
public class CharacterInitialData : ScriptableObject
{
    [field: SerializeField]
    public IdleData IdleData
    { get; set; }

    [field: SerializeField]
    public MovementData MovementData
    {  get; set; }
}
