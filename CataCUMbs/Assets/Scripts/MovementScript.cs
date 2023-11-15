using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // Adjust the speed as needed
    [SerializeField] float rotationSpeed = 20; // Adjust the rotation speed as needed
    float rotationDegrees = 75;

    private Rigidbody2D rb;
    private bool isMoving = false;

    Vector3 currentRotation;
    [SerializeField] GameObject targetDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = !isMoving;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isMoving = !isMoving;
        }

        if (!isMoving)
        {
            RotatePlayer();
        }
    }

    private void FixedUpdate()
    {
        if(isMoving)
        {
            MovePlayer();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void RotatePlayer()
    {
        currentRotation.z += Time.deltaTime * rotationSpeed;
        float rotation = Mathf.Sin(currentRotation.z) * rotationDegrees;
        targetDirection.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }

    void MovePlayer()
    {
        // Move the player in the direction they are facing
        Vector2 moveDirection = targetDirection.transform.up;
        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }
}