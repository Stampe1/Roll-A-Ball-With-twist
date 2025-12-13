using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    public GameObject TeleportTarget;
    public GameObject LevelRoof;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = new Vector3(0, 1, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = TeleportTarget.transform.position + offset;
            LevelRoof.gameObject.SetActive(false);
        }
    }
}
