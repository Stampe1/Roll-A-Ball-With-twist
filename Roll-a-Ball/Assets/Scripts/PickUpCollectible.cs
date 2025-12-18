using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    public TextMeshProUGUI deathText; 
    public static int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Add code to handle the pickup logic, e.g., increase score, play sound, etc.
            score++;
            Debug.Log("Collectible picked up! Score: "+score);
            Destroy(gameObject); // Remove the collectible from the scene
        }

        
      
    }
}
