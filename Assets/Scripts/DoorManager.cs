using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static int collectedCards = 0;

    [SerializeField] private int requiredCards = 2;

    private BoxCollider2D doorCollider;
    private SpriteRenderer doorSprite;
    private bool opened;

    private void Awake()
    {
        collectedCards = 0;
    }

    private void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        doorSprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (opened)
            return;

        if (collision.gameObject.CompareTag("Player") &&
            collectedCards >= requiredCards)
        {
            opened = true;
            doorCollider.enabled = false;
            doorSprite.enabled = false;

            Debug.Log("Porta aberta!");
        }
    }
}