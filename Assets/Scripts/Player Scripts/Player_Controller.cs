using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody rb;  // Reference to the Rigidbody component
    private Player_Animator playerAnimator;  // Reference to the Player_Animator script
    private Input_Handler inputHandler;  // Reference to the Input_Handler script
    private Player_Health playerHealth;  // Reference to the Player_Health script

    [SerializeField] float playerSpeed = 2f, jumpHeight = 1f, rotationSpeed = 4f;  // Player movement settings

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();  // Get the Rigidbody component
        playerAnimator = GetComponent<Player_Animator>();  // Get the Player_Animator script
        inputHandler = GetComponent<Input_Handler>();  // Get the Input_Handler script
        playerHealth = GetComponent<Player_Health>();  // Get the Player_Health script
        rb.freezeRotation = true;  // Prevent the Rigidbody from automatically rotating
    }

    private void Update()
    {
        MovePlayer();  // Handle player movement

        if (inputHandler.IsJumping() && IsGrounded())
        {
            HandleJump();  // Handle player jump if the player is grounded
        }

        CheckPlayerHealth();  // Check player's health status
    }

    private void MovePlayer()
    {
        Vector3 movement = inputHandler.GetPlayerMovement() * playerSpeed;
        Vector3 horizontalVelocity = new(movement.x, rb.velocity.y, movement.z);

        rb.Move(transform.position + horizontalVelocity * Time.deltaTime, transform.rotation);  // Move the player

        if (inputHandler.GetPlayerMovement() != Vector3.zero)
        {
            Quaternion targetRotation = inputHandler.GetPlayerRotation();
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);  // Smoothly rotate the player

            playerAnimator.MovePlayer(true);  // Trigger movement animation
        }
        else
        {
            playerAnimator.MovePlayer(false);  // Stop movement animation
        }
    }

    private void HandleJump()
    {
        playerAnimator.TriggerJump();  // Trigger jump animation
        rb.AddForce(inputHandler.GetPlayerJumpForce(jumpHeight), ForceMode.Impulse);  // Apply jump force to the player
    }

    private void CheckPlayerHealth()
    {
        if (playerHealth.GetHealth() <= 0 && IsGrounded())
        {
            playerAnimator.KillPlayer();  // Trigger death animation
            inputHandler.DisableControls();  // Disable player controls
            Game_Manager.Instance.GameOver();  // Trigger game over logic
        }
    }

    // Checks if the player is grounded using a raycast
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, out _, 0.1f);
    }
}
