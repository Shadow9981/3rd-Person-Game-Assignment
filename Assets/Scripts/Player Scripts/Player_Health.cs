using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private float maxHealth, currentHealth;  // Health values for the player
    [SerializeField] private Slider healthBar;  // UI slider to display health

    private void Start()
    {
        healthBar.value = maxHealth;  // Initialize health bar to max health
        currentHealth = maxHealth;  // Set current health to max health
    }

    // Reduces the player's health and updates the health bar
    public void DamagePlayer(int health)
    {
        currentHealth -= health;
        healthBar.value = currentHealth;
    }

    // Returns the player's current health
    public float GetHealth()
    {
        return currentHealth;
    }
}
