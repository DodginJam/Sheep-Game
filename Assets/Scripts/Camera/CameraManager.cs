using UnityEngine;

public class CameraManager : MonoBehaviour
{
    /// <summary>
    /// The camera used by the player to see the scene during gameplay.
    /// </summary>
    [field: SerializeField, Header("Camera and Target")]
    public Camera PlayerCamera
    { get; private set; }

    /// <summary>
    /// The gameobject that is assigned to the camera as the target to follow.
    /// </summary>
    [field: SerializeField]
    public GameObject AssignedTarget
    { get; private set; }

    /// <summary>
    /// The position of the target from the last frame.
    /// </summary>
    public Vector3 LastFrameTargetPosition
    { get; private set; }

    /// <summary>
    /// The camera positional offset from the assigned target - used to maintain camera distance from target.
    /// </summary>
    [field: SerializeField]
    public Vector3 CameraPositionalOffset
    { get; private set; }

    /// <summary>
    /// The cameras rotation maintained during gameplay.
    /// </summary>
    [field: SerializeField]
    public Vector3 CameraRotation
    { get; private set; }

    /// <summary>
    /// The base speed of movement the camera has when moving towards the players direction of movement.
    /// </summary>
    [field: SerializeField, Header("Camera Movement")]
    public float CameraLerpSpeed
    { get; private set; } = 5.0f;

    /// <summary>
    /// The distance away from the viewport centre that the player can move before the Vector3 lerping starts.
    /// </summary>
    [field: SerializeField]
    public float Viewport_CentreDistanceToLerp
    { get; private set; } = 0.33f;

    /// <summary>
    /// The distance between camera and default centered position at which the camera should stop lerping.
    /// </summary>
    [field: SerializeField]
    public float DistanceToStopLerp
    { get; private set; } = 0.1f;

    /// <summary>
    /// The distance the camera should move infront of the player in their projected direction of movement.
    /// </summary>
    [field: SerializeField]
    public float ProjectedLerpDistanceFromPlayerMovement
    { get; private set; } = 5.0f;

    /// <summary>
    /// The deadzone that the mouse should be from the centre viewport before the mouse influences camera position.
    /// </summary>
    [field: SerializeField]
    public float MouseDeadZoneFromVirewPortCentre
    { get; private set; }

    /// <summary>
    /// The maximum distance from the CalculatedCameraPositiion position the camera will move away from.
    /// </summary>
    [field: SerializeField]
    public float MouseCameraMaximumDistance
    { get; private set; }

    public CameraMovementStatus CamMovementStatus
    { get; private set; }

    /// <summary>
    /// Used to store the CalculatedCameraPosition and to be assigned to the Camera Transform Position at the end of the update loop.
    /// </summary>
    public Vector3 CalculatedCameraPosition
    { get; private set; }

    /// <summary>
    /// The sub-state for the camera
    /// </summary>
    public enum CameraMovementStatus
    {
        Centered,
        MovingToPlayerPredicated
    }

    private void Awake()
    {
        if (PlayerCamera == null)
        {
            PlayerCamera = Camera.main;

            if (PlayerCamera == null)
            {
                Debug.LogError("Unable to locate a player camera in the scene.");
            }
        }

        if (AssignedTarget == null)
        {
            // If no target has been assigned, locate the first player character in the scene.
            AssignedTarget = GameObject.FindFirstObjectByType<StateManager_Player>().gameObject;

            if (AssignedTarget == null)
            {
                Debug.LogError("Unable to locate a gameobject for the camera to follow as no gameobject has the state manager script attached.");
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CamMovementStatus = CameraMovementStatus.Centered;

        CalculatedCameraPosition = AssignedTarget.transform.position + CameraPositionalOffset;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        UpdateCameraPosition();
        UpdateCameraRotation();
    }

    /// <summary>
    /// Keep the cameras position updated relative to the assigned targets position and projected path.
    /// </summary>
    public void UpdateCameraPosition()
    {
        // The Vector3 position that the MoveTowards is to be assigend to is referenced here before being assigned to CalculatedCameraPosition.
        Vector3 cameraPositionToMoveToo = Vector3.zero;

        Vector3 playerViewportPosition = PlayerCamera.WorldToViewportPoint(AssignedTarget.transform.position);

        // Should be in this state when the player is not moving.
        if (CamMovementStatus == CameraMovementStatus.Centered)
        {
            float viewportCentre = 0.5f;

            MouseDeadZoneCheck();

            // If the player is outside the bounds of the given viewport view bounds, then change the camera movement status to moving towards the player.
            if (playerViewportPosition.x > (viewportCentre + Viewport_CentreDistanceToLerp) || playerViewportPosition.x < (viewportCentre - Viewport_CentreDistanceToLerp) || playerViewportPosition.y > (viewportCentre + Viewport_CentreDistanceToLerp) || playerViewportPosition.y < (viewportCentre - Viewport_CentreDistanceToLerp))
            {
                CamMovementStatus = CameraMovementStatus.MovingToPlayerPredicated;

                // Update the last position of the assigned target position when entering the moving to player state.
                LastFrameTargetPosition = AssignedTarget.transform.position;
            }
        }
        else if (CamMovementStatus == CameraMovementStatus.MovingToPlayerPredicated)
        {
            // Get the normalized direction of movement using last frame assigned target position.
            Vector3 targetDirectionOfMovement = (AssignedTarget.transform.position - LastFrameTargetPosition).normalized;

            // The position infront of the player for the camera to move towards.
            Vector3 projectedTargetPosition = AssignedTarget.transform.position + (targetDirectionOfMovement * ProjectedLerpDistanceFromPlayerMovement);

            // Update the calculated camera position to the current lerped positions between thw cameras current position and the projected target position.
            cameraPositionToMoveToo = projectedTargetPosition + CameraPositionalOffset;

            MouseDeadZoneCheck();

            // The camera only resets to the centered type movement when the player has stopped moving.
            bool hasPlayerStoppedMoving = LastFrameTargetPosition == AssignedTarget.transform.position;

            // Reset the camera to centered on target behaviour when the distance between the camera and the desired position is at a neligable distance.
            if (Vector3.Distance(PlayerCamera.transform.position, projectedTargetPosition + CameraPositionalOffset) < DistanceToStopLerp && hasPlayerStoppedMoving)
            {
                CamMovementStatus = CameraMovementStatus.Centered;
            }
            else
            {
                // Reassign the lastframe position to the current position of the target as the last thing to do for this frames loop to allow next update to have updated last frame position.
                LastFrameTargetPosition = AssignedTarget.transform.position;
            }
        }

        // Calculate the new camera position and then assigned the PlayerCamera to that position.
        CalculatedCameraPosition = Vector3.MoveTowards(PlayerCamera.transform.position, cameraPositionToMoveToo, CameraLerpSpeed * Time.deltaTime);
        PlayerCamera.transform.position = CalculatedCameraPosition;

        void MouseDeadZoneCheck()
        {
            bool isMouseOutsideDeadzone = IsMouseOutsideDeadZone(out Vector2 mouseInViewPortSpace);

            if (isMouseOutsideDeadzone)
            {
                if (CamMovementStatus == CameraMovementStatus.MovingToPlayerPredicated)
                {
                    // Get the position of the mouse and add the change of camera based on the mouse position to the cameraPositionToMoveToo.

                }
                else if (CamMovementStatus == CameraMovementStatus.Centered)
                {
                    // Assigned cameraPositionToMoveToo to the current position since no change is needed from movement.
                    cameraPositionToMoveToo = PlayerCamera.transform.position;

                    // Get the position of the mouse and add the change of camera based on the mouse position to the cameraPositionToMoveToo.

                }
            }
            else
            {
                if (CamMovementStatus == CameraMovementStatus.MovingToPlayerPredicated)
                {
                    // Already calculated cameraPositionToMoveToo so no action needed.
                }
                else if (CamMovementStatus == CameraMovementStatus.Centered)
                {
                    // Assigned cameraPositionToMoveToo to the current position since no change is needed when the camera is centered.
                    cameraPositionToMoveToo = PlayerCamera.transform.position;
                }
            }
        }
    }

    /// <summary>
    /// Update the cameras rotation if it is not equal to the provied coordinates.
    /// </summary>
    public void UpdateCameraRotation()
    {
        if (PlayerCamera.transform.rotation.eulerAngles != CameraRotation)
        {
            PlayerCamera.transform.rotation = Quaternion.Euler(CameraRotation);
        }
    }

    public bool IsMouseOutsideDeadZone(out Vector2 mousePositionViewPort)
    {
        float viewPortCentre = 0.5f;

        mousePositionViewPort = PlayerCamera.ScreenToViewportPoint(Input.mousePosition);

        if (mousePositionViewPort.x > (viewPortCentre + MouseDeadZoneFromVirewPortCentre) || mousePositionViewPort.y > (viewPortCentre + MouseDeadZoneFromVirewPortCentre) || mousePositionViewPort.x < (viewPortCentre - MouseDeadZoneFromVirewPortCentre) || mousePositionViewPort.y < (viewPortCentre - MouseDeadZoneFromVirewPortCentre))
        {
            Debug.Log("Out the deadzone bounds");
            return true;
        }
        else
        {
            Debug.Log("In the deadzone bounds");
            return false;
        }
    }
}
