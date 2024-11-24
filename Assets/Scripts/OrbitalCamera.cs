using UnityEngine;

public class MouseOrbitCamera : MonoBehaviour
{
    public Transform cameraAnchor; // Assign the CameraAnchor in the Inspector
    public float rotationSpeed = 375f; // Speed of rotation
    public float verticalClampAngle = 10f; // Clamp for vertical rotation (to prevent flipping)

    private float horizontalAngle = 0f; // Horizontal rotation angle (Y-axis)
    private float verticalAngle = 0f;   // Vertical rotation angle (X-axis)

    void Start()
    {
        // Initialize rotation angles based on the anchor's current rotation
        Vector3 anchorRotation = cameraAnchor.eulerAngles;
        horizontalAngle = anchorRotation.y;
        verticalAngle = anchorRotation.x;
    }

    void Update()
    {
        // Check if the right mouse button is held down
        if (Input.GetMouseButton(1)) // 1 = Right Mouse Button
        {
            // Get mouse input
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Adjust angles based on mouse movement
            horizontalAngle += mouseX * rotationSpeed * Time.deltaTime;
            verticalAngle -= mouseY * rotationSpeed * Time.deltaTime; // Invert Y for intuitive control

            // Clamp the vertical angle to prevent the camera from flipping
            verticalAngle = Mathf.Clamp(verticalAngle, -verticalClampAngle, verticalClampAngle);

            // Apply the rotation to the camera anchor
            cameraAnchor.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);
        }
    }
}
