using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Handler : MonoBehaviour
{
    private Transform mainCamTransform;  // Reference to the main camera's transform
    private Vector2 movementVector;  // Stores the movement input
    [SerializeField] private InputActionReference movementControl, jumpControl;  // References to input actions

    private void Start() 
    {
        mainCamTransform = Camera.main.transform;  // Get the main camera's transform

        // Hide and lock the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable() 
    {
        movementControl.action.Enable();  // Enable movement input
        jumpControl.action.Enable();  // Enable jump input
    }

    private void OnDisable() 
    {
        movementControl.action.Disable();  // Disable movement input
        jumpControl.action.Disable();  // Disable jump input  
    }

    // Calculates and returns the player's movement vector relative to the camera
    public Vector3 GetPlayerMovement()
    {
        movementVector = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementVector.x, 0, movementVector.y);
        move = mainCamTransform.transform.forward * move.z + mainCamTransform.transform.right * move.x;
        move.y = 0;
        return move;
    }

    // Calculates and returns the player's rotation based on input
    public Quaternion GetPlayerRotation()
    {
        float targetAngle = Mathf.Atan2(movementVector.x, movementVector.y) * Mathf.Rad2Deg + mainCamTransform.eulerAngles.y;
        return Quaternion.Euler(0, targetAngle, 0);
    }

    // Returns the jump force vector when the player jumps
    public Vector3 GetPlayerJumpForce(float jumpHeight)
    {
        return jumpHeight * Vector3.up + 0.5f * Vector3.forward;
    }

    // Disables all controls
    public void DisableControls()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();  
    }
    
    // Checks if the jump action has been triggered
    public bool IsJumping() => jumpControl.action.triggered;
}