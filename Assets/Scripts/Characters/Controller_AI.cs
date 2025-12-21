using UnityEngine;
using UnityEngine.AI;

public class Controller_AI : Controller, IAILocomotion
{
    public InputHandler_AI AIInput
    { get; set; }

    public NavMeshPath Path
    { get; set; }

    public override void Initialise()
    {
        base.Initialise();


    }
}

public interface IAILocomotion
{
    public InputHandler_AI AIInput
    { get; set; }

    public NavMeshPath Path
    { get; set; }
}
