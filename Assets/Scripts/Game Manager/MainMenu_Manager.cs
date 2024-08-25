using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Manager : MonoBehaviour
{
    [SerializeField] private GameObject objectivePanel;  // Displays objectives before starting the game

    // Quits the application
    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    // Shows the objectives panel when Play is pressed
    public void PlayButtonPressed()
    {
        objectivePanel.SetActive(true);
    }

    // Starts the game by loading the game scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
