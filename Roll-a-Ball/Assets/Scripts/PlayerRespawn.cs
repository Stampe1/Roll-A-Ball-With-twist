using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 currentSpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpawnPoint = transform.position;
    }

    
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        currentSpawnPoint = newSpawnPoint;
    }

    public void Respawn()
    {
        transform.position = currentSpawnPoint;
        
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {
            GetComponent<PlayerRespawn>().Respawn();
        }
    }
}
