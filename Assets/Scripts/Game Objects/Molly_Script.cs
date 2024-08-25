using System.Collections;
using UnityEngine;

public class Molly_Script : MonoBehaviour
{
    [SerializeField] private int damage = 10;  // Damage inflicted on the player
    [SerializeField] private float damageInterval = 2f;  // Time interval between damage infliction

    private bool playerInMolly = false;  // Tracks if the player is within the damaging area
    private Coroutine damageCoroutine;  // Coroutine that handles damage over time

    // Detects when the player enters the molotov's area of effect
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Burning");
            playerInMolly = true;  // Player is in the molotov's area
            damageCoroutine = StartCoroutine(DamagePlayerOverTime(other.gameObject));  // Start damaging the player over time
        }    
    }

    // Detects when the player exits the molotov's area of effect
    private void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInMolly = false;  // Player has left the molotov's area
            StopCoroutine(damageCoroutine);  // Stop damaging the player
        }
    }

    // Coroutine that inflicts damage on the player at regular intervals
    private IEnumerator DamagePlayerOverTime(GameObject player)
    {
        while (playerInMolly)
        {
            Game_Manager.Instance.DamagePlayer(damage);  // Inflict damage
            yield return new WaitForSeconds(damageInterval);  // Wait before inflicting damage again
        }
    }
}
