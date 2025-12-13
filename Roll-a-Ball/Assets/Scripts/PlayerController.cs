using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public int score;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue MovementValue)
    {
        Vector2 MovementVector = MovementValue.Get<Vector2>();

        movementX = MovementVector.x;
        movementY = MovementVector.y;
    }

    void SetCountText()
    {
        countText.text = "count: " + count.ToString();

        if (count >= 5)
        {
            winTextObject.SetActive(true);
        }
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
            count = count + 1;
            SetCountText();
        }



    }
}
