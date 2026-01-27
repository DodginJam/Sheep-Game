using Unity.Netcode;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [field: SerializeField]
    public Camera PlayerCamera
    { get; private set; }

    public Controller AssignedController
    { get; private set; }

    [field: SerializeField]
    public Vector3 CameraOffset
    { get; private set; } = new Vector3(0, 30, 0);

    [field: SerializeField]
    public Vector3 CameraRotation
    { get; private set; } = new Vector3(90, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerCamera == null)
        {
            PlayerCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AssignedController != null)
        {
            PlayerCamera.transform.position = AssignedController.transform.position + CameraOffset;
        }
    }

    public void AssignOwner(Controller controller)
    {
        controller.CameraManager = this;

        AssignedController = controller;

        Debug.Log("Camera Manager assigned to owner in controller.");
    }
}
