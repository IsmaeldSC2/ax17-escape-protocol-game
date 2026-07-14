using UnityEngine;

public class DoorExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && DoorManager.hasAccessCard)
        {
            Debug.Log("Fase concluída!");
        }
    }
}