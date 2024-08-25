using UnityEngine;

public class Player_Animator : MonoBehaviour
{
    Animator animator;  // Reference to the Animator component
    readonly int isMoving = Animator.StringToHash("isMoving");  // Hash for "isMoving" parameter
    readonly int isJumping = Animator.StringToHash("isJumping");  // Hash for "isJumping" trigger
    readonly int isDead = Animator.StringToHash("isDead");  // Hash for "isDead" parameter

    private void Awake() 
    {
        animator = GetComponent<Animator>();  // Get the Animator component    
    }

    // Triggers the movement animation
    public void MovePlayer(bool moving)
    {
        animator.SetBool(isMoving, moving);
    }

    // Triggers the jump animation
    public void TriggerJump()
    {
        animator.SetTrigger(isJumping);
    }

    // Triggers the death animation
    public void KillPlayer()
    {
        animator.SetBool(isDead, true);
    }
}
