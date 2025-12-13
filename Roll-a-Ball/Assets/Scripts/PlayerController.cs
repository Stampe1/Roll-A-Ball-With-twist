using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public int score;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue MovementValue)
    {
        Vector2 MovementVector = MovementValue.Get<Vector2>();

        movementX = MovementVector.x;
        movementY = MovementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {

            // Add code to handle the pickup logic, e.g., increase score, play sound, etc.
            score++;
            Debug.Log("Collectible picked up! Score: " + score);
            other.gameObject.SetActive(false); // Remove the collectible from the scene
        }



    }
}
