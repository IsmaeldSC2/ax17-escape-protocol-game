using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (string.IsNullOrWhiteSpace(nextSceneName))
        {
            Debug.LogError("A próxima cena não foi configurada no LevelExit.", this);
            return;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}