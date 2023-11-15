using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // Adjust the speed as needed
    [SerializeField] float rotationSpeed = 20; // Adjust the rotation speed as needed
    float rotationDegrees = 90;

    private Rigidbody2D rb;
    private bool isMoving = false;

    Vector3 currentRotation;

    [SerializeField] GameObject fogObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = !isMoving;
            currentRotation.z = transform.rotation.z;

            Debug.Log(currentRotation.z);
            Debug.Log(transform.rotation.z);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isMoving = !isMoving;
        }

        if(isMoving)
        {
            MovePlayer();
        }
        else
        {
            rb.velocity = Vector2.zero;
            RotatePlayer();
        }

        UpdateFogPosition();
    }

    void RotatePlayer()
    {
        currentRotation.z += Time.deltaTime * rotationSpeed;
        float rotation = Mathf.Sin(currentRotation.z) * rotationDegrees;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }

    void MovePlayer()
    {
        // Move the player in the direction they are facing
        Vector2 moveDirection = transform.up;
        rb.velocity = moveDirection * moveSpeed;
    }

    void UpdateFogPosition()
    {
        fogObject.transform.position = transform.position;
    }
}