using UnityEngine;

public class AccessCardPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DoorManager.hasAccessCard = true;
            Destroy(gameObject);
        }
    }
}