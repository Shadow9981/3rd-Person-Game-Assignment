using UnityEngine;

public class Hammer_Script : MonoBehaviour
{
    [SerializeField] private float swingSpeed = 2.0f;  // Speed of the hammer swing
    [SerializeField] private float maxSwingAngle = 45.0f;  // Maximum angle of swing
    [SerializeField] private bool swingRightFirst = true;  // Direction of the initial swing
    [SerializeField] private float hitForce = 10.0f;  // Force applied to the player when hit

    private float startAngle;  // Initial angle of the hammer
    private Quaternion startRotation;  // Initial rotation of the hammer
    private Rigidbody rb;  // Rigidbody component of the hammer

    void Start()
    {
        startRotation = transform.rotation;  // Store initial rotation
        startAngle = transform.eulerAngles.z;  // Store initial angle
 
        if (!swingRightFirst)
        {
            swingSpeed = -swingSpeed;  // Reverse swing direction if specified
        }

        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
    }

    void Update()
    {
        SwingHammer();
    }

    // Calculate the new swing angle based on time
    private void SwingHammer()
    {
        float angle = maxSwingAngle * Mathf.Sin(Time.time * swingSpeed);

        transform.rotation = startRotation * Quaternion.Euler(0, 0, angle);
    }

    // Detects collision with the player
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hammered");
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 forceDirection = transform.right * Mathf.Sign(swingSpeed);

            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.AddForce(forceDirection * hitForce, ForceMode.Impulse);
                Game_Manager.Instance.DamagePlayer(40);
            }
        }
    }
}
