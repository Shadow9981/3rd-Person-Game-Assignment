using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;  // Singleton instance for global access
    [SerializeField] private Score_Manager scoreManager;  // Manages the player's score
    [SerializeField] private UI_Manager uiManager;  // Controls UI elements like game over and win screens
    [SerializeField] private Player_Health playerHealth;  // Handles player's health

    private void Awake() 
    {
        // Ensure only one instance of Game_Manager exists
        if(Instance != this && Instance != null)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);  // Persist Game_Manager across scenes
    }

    // Updates the score and checks if the player has won
    public void UpdateScore(int points)
    {
        scoreManager.IncreaseScore(points);

        if(scoreManager.MaxScoreReached())
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            uiManager.SetText("YOU WIN!!!");
            uiManager.ActivatePanel();
        }
    }

    // Handles game over logic
    public void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        uiManager.SetText("GAME OVER");
        uiManager.ActivatePanel();
    }

    // Applies damage to the player
    public void DamagePlayer(int damage) => playerHealth.DamagePlayer(damage);
}
