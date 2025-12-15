using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Set spawn when touching spawner
            PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.SetSpawnPoint(spawnPoint.position);
            }
        }
    }
}
