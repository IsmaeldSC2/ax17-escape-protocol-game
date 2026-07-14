using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField]
    private VictoryUI victoryUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && DoorManager.hasAccessCard)
        {
            victoryUI.ShowVictory();
            Debug.Log("Fase concluída!");
        }
    }
}