using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public int score;
    public GameObject winTextObject;
    public float jumpForce;
    public TextMeshProUGUI jumpText;
    public bool isGrounded;
    public int jumpCount;
    public Transform cameraFollowTarget;
    
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
        jumpCount = 2;
        SetJumpCount();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 MovementVector = movementValue.Get<Vector2>();

        movementX = MovementVector.x;
        movementY = MovementVector.y;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnJump()
    {
        
        if (jumpCount > 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jumpCount--;
        }
        else
        {
            Debug.Log("Cant jump");
        }
        SetJumpCount();
    }

    void SetJumpCount()
    {
        jumpText.text = "Jumps left: " + jumpCount.ToString();
    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();

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
            //Jumps
            if (other.CompareTag("Ground"))
            {
                jumpCount = 2;
                SetJumpCount();
            }

            if (other.CompareTag("Teleporter"))
            {
                
            }
            
            


    }
    
    
}
