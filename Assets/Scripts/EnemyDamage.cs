using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private CanvasGroup deathScreen;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float delayBeforeReload = 1.5f;

    private bool isPlayerCaught = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlayerCaught) return;

        if (other.CompareTag("Player"))
        {
            isPlayerCaught = true;
            Debug.Log("Jogador capturado!");

            // Trava o movimento do player
            var playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null) playerMovement.enabled = false;

            var rb = other.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;

            StartCoroutine(CaptureSequence());
        }
    }

    private IEnumerator CaptureSequence()
    {
        if (deathScreen != null)
        {
            deathScreen.gameObject.SetActive(true);
            deathScreen.blocksRaycasts = true;

            float elapsed = 0f;
            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                deathScreen.alpha = Mathf.Clamp01(elapsed / fadeDuration);
                yield return null;
            }
            deathScreen.alpha = 1f;
        }

        yield return new WaitForSeconds(delayBeforeReload);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}