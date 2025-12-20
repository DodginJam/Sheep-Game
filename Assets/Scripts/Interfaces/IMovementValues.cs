using UnityEngine;

public interface IMovementValues
{
    public float MovementSpeed
    { get; set; }

    public static void ApplyData(IMovementValues dataToRead, IMovementValues dataToApply)
    {
        dataToApply.MovementSpeed = dataToRead.MovementSpeed;
    }
}
