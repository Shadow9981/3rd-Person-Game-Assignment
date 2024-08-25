using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;  // Displays the game over or win message
    [SerializeField] GameObject gameOverPanel;  // Panel that shows game over or win message

    private void Start() 
    {
        gameOverPanel.SetActive(false);  // Initially hide the game over panel
    }

    // Sets the text of the game over panel
    public void SetText(string text)
    {
        gameOverText.text = text;
    }

    // Restarts the game by reloading the current level
    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    // Returns to the main menu
    public void BackButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    // Activates the game over panel
    public void ActivatePanel()
    {
        gameOverPanel.SetActive(true);
    }
}
