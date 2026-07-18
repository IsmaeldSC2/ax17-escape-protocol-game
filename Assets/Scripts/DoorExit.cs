using UnityEngine;

public class DoorExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        DoorManager doorManager = GetComponent<DoorManager>();

        if (doorManager == null)
        {
            Debug.LogError("DoorManager não encontrado na porta.", this);
            return;
        }
    }
}