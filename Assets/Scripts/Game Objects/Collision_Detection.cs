using UnityEngine;

public class Collision_Detection : MonoBehaviour
{
    private string playerTag = "Player";  // Tag used to identify the player
    [SerializeField] GameObject collectible;  // The collectible item to be destroyed
    [SerializeField] Collider sphereCollider;  // The collider that triggers the event

    // Detects collision with the player and update the score
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag(playerTag))
        {
            Game_Manager.Instance.UpdateScore(1);
            Destroy(collectible);
            sphereCollider.enabled = false;
        }
    }
}
