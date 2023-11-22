using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this to control the movement speed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from arrow keys or WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the movement vector to ensure constant speed in all directions
        movement.Normalize();

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime);

        // For example, you might use the 'R' key to trigger a restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.instance.RestartScene();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check for hazards or points
        if (other.CompareTag("Hazard"))
        {
            // Handle hazard collision (e.g., take damage, reset position, etc.)
            Debug.Log("Hit Hazard!");
            // Implement your hazard logic here
        }
        else if (other.CompareTag("Point"))
        {

            // Assume each collected point is worth 10 points
            int pointsToAdd = 10;

            // Call the CollectPoints method of the PointsManager
            PointsManager pointsManager = FindObjectOfType<PointsManager>();
            if (pointsManager != null)
            {
                pointsManager.CollectPoints(pointsToAdd);
            }

            // Handle point collection (e.g., increase score, play sound, etc.)
            Debug.Log("Collected Point!");
            // Implement your point collection logic here
            Destroy(other.gameObject); // Destroy the collected point object
        }
    }
}