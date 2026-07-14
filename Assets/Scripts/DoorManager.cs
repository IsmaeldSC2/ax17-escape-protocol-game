using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static bool hasAccessCard = false;

    private BoxCollider2D doorCollider;
    private SpriteRenderer doorSprite;

    private void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        doorSprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasAccessCard)
        {
            doorCollider.enabled = false;
            doorSprite.enabled = false;

            Debug.Log("Porta aberta!");
        }
    }
}