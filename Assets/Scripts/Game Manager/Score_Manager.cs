using TMPro;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;  // Displays the number of keys collected
    private int keys;  // Tracks the current number of keys collected
    private int maxKeys = 2;  // Total number of keys needed to win

    // Increases the score and updates the UI
    public void IncreaseScore(int points)
    {
        keys += points;
        scoreText.text = "Keys Collected : " + keys + " / " + maxKeys;
    }

    // Checks if the player has collected all keys
    public bool MaxScoreReached() => keys == maxKeys;
}
